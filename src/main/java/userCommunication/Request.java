package userCommunication;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import de.schildbach.pte.*;
import de.schildbach.pte.dto.Location;
import de.schildbach.pte.dto.LocationType;
import de.schildbach.pte.dto.Trip;

public class Request {

	private Trip.Leg forJourney;
	private List<Trip.Leg> potentiallyCollidingTrains = new ArrayList<Trip.Leg>();
	private int chatId;

	private static Location KARLSRUHE = new Location(LocationType.STATION, "8000191"),
			HEIDELBERG = new Location(LocationType.STATION, "8000156"),
			STUTTGART = new Location(LocationType.STATION, "8000096"),
			WALLDORF = new Location(LocationType.STATION, "8006421");

	private NetworkProvider networkProvider;

	public Request(Trip.Leg forJourney, NetworkProvider networkProvider) {
		this.forJourney = forJourney;
		this.networkProvider = networkProvider;

		try {
			Date departAfter = new Date(forJourney.getDepartureTime().getTime() - 20 * 60 * 1000);
			List<Trip> trips;
			(trips = networkProvider.queryTrips(STUTTGART, null, HEIDELBERG, forJourney.getDepartureTime(), true, null,
					null, null, null, null).trips)
							.addAll(networkProvider.queryTrips(KARLSRUHE, null, HEIDELBERG,
									forJourney.getDepartureTime(), true, null, null, null, null, null).trips);
			trips.removeIf(trip -> trip.getLastArrivalTime()
					.before(new Date(forJourney.getArrivalTime().getTime() + 20 * 60 * 1000)));
			trips.forEach(trip -> potentiallyCollidingTrains.addAll(trip.legs));

		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}
}
