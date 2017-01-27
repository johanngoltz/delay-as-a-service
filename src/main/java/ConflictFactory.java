import java.io.IOException;
import java.util.ArrayList;
import java.util.Collection;
import java.util.Date;
import java.util.List;
import java.util.stream.Collectors;

import de.schildbach.pte.NetworkProvider;
import de.schildbach.pte.dto.Location;
import de.schildbach.pte.dto.LocationType;
import de.schildbach.pte.dto.Trip;
import de.schildbach.pte.dto.Trip.Public;

import com.google.common.*;

public class ConflictFactory
{
	private static Location KARLSRUHE = new Location(LocationType.STATION, "8000191"),
			HEIDELBERG = new Location(LocationType.STATION, "8000156"),
			STUTTGART = new Location(LocationType.STATION, "8000096"),
			WALLDORF = new Location(LocationType.STATION, "8006421");

	private final int EPSILON = 20;

	private NetworkProvider networkProvider;

	public ConflictFactory(NetworkProvider networkProvider)
	{
		this.networkProvider = networkProvider;
	}

	public List<Conflict> getPotentialConflicts(Trip forTrip)
	{
		List<Conflict> potentialConflicts = new ArrayList<Conflict>();

		for (Trip.Leg leg : forTrip.legs)
			if (leg instanceof Trip.Public)
			{
				Trip.Public publicLeg = (Public) leg;
				try
				{
					Date departAfter = new Date(publicLeg.getDepartureTime().getTime() - EPSILON * 60 * 1000),
							arriveBefore = new Date(publicLeg.getArrivalTime().getTime() + EPSILON * 60 * 1000);
					List<Trip> trips;
					List<Trip.Public> potentiallyConflictingLegs;
					//@formatter:off
					(trips = networkProvider.queryTrips(
								STUTTGART, null, HEIDELBERG, departAfter, true, null, null, null, null, null)
							.trips)
							.addAll(networkProvider.queryTrips(
								KARLSRUHE, null, HEIDELBERG, departAfter, true, null, null, null, null, null)
							.trips);
					//@formatter:on
					potentialConflicts.addAll(
							trips.parallelStream()
									.map(trip -> trip.legs
											.parallelStream()
											.filter(l -> l instanceof Trip.Public)
											.map(l -> (Trip.Public) l)
											.collect(Collectors.toList()))
									.flatMap(publicLegs -> publicLegs
											.parallelStream()
											// TODO: Filter out Trains of same or lower product category
											.map(conflictingPublicLeg -> new Conflict(forTrip.getLastPublicLeg(),
													conflictingPublicLeg)))
									.collect(Collectors.toList()));

				} catch (IOException e)
				{
					// TODO Auto-generated catch block
					e.printStackTrace();
				}
			}

		return potentialConflicts;
	}
}
