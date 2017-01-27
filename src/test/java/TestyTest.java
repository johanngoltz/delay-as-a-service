import java.io.IOException;
import java.util.Date;
import java.util.EnumSet;
import java.util.List;

import de.schildbach.pte.BahnProvider;
import de.schildbach.pte.KvvProvider;
import de.schildbach.pte.NetworkProvider;
import de.schildbach.pte.dto.*;
import de.schildbach.pte.dto.QueryTripsResult.Status;

public class TestyTest
{
	private static Location KARLSRUHE = new Location(LocationType.STATION, "8000191"),
			HEIDELBERG = new Location(LocationType.STATION, "8000156"),
			STUTTGART = new Location(LocationType.STATION, "8000096"),
			WALLDORF = new Location(LocationType.STATION, "8006421");

	public static void main(String[] args)
	{
		NetworkProvider networkProvider = new BahnProvider();
		
		Trip trip = null;
		try
		{
			trip = networkProvider.queryTrips(KARLSRUHE, null, WALLDORF, new Date(), true, EnumSet.of(Product.SUBURBAN_TRAIN), null, null, null, null).trips.get(0);
		} catch (IOException e)
		{
			// TODO Auto-generated catch block
			e.printStackTrace();
		}

		ConflictFactory conflictFactory = new ConflictFactory(networkProvider);
		
		conflictFactory.getPotentialConflicts(trip);
	}
}
