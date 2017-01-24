import java.io.IOException;
import java.util.Date;
import java.util.EnumSet;
import java.util.List;

import de.schildbach.pte.BahnProvider;
import de.schildbach.pte.KvvProvider;
import de.schildbach.pte.NetworkProvider;
import de.schildbach.pte.dto.*;
import de.schildbach.pte.dto.QueryTripsResult.Status;
public class TestyTest {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		NetworkProvider provider =  new BahnProvider();
		@SuppressWarnings("unused")
		SuggestLocationsResult sLR = null;
		try {
			sLR = provider.suggestLocations("Heidelberg HBF");
		} catch (IOException e2) {
			// TODO Auto-generated catch block
			e2.printStackTrace();
		}
		Location karlsruhe = new Location(LocationType.STATION, "8000191");
		@SuppressWarnings("unused")
		NearbyLocationsResult nLR;
		try {
			nLR = provider.queryNearbyLocations(EnumSet.of(LocationType.STATION), karlsruhe, 10000, 10000);
		} catch (IOException e1) {
			// TODO Auto-generated catch block
			e1.printStackTrace();
		}
		Location walldorf = new Location(LocationType.STATION, "8006421");
		List<Trip> trips = null;
		try {
			QueryTripsResult qTR = provider.queryTrips(karlsruhe, null, walldorf, new Date(), true, Product.ALL, null, null, null, null);
			while(!qTR.status.equals(Status.OK));
			trips = qTR.trips;
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		
		for(Trip trip : trips)
			for(Trip.Leg leg : trip.legs)
				leg.getDepartureTime();
	}
	
	public static void getConflictingTrains(List<Trip >trips){
		Location stuttgart = new Location(LocationType.STATION, "8000096");
		Location heidelberg = new Location(LocationType.STATION, "8000156");
		NetworkProvider provider =  new BahnProvider();
		List<Trip> conflictingTrips = null;
		try {
			QueryTripsResult qTR = provider.queryTrips(stuttgart, null, heidelberg, new Date(), false, Product.ALL, null, null, null, null);
			conflictingTrips = qTR.trips;
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		
		
	}

}
