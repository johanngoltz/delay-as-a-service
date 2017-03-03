package transport;
import de.schildbach.pte.dto.Trip;

public class Conflict {
	private Trip.Public forLeg;
	private Trip.Public conflictingLeg;
	
	public Conflict(Trip.Public forLeg, Trip.Public conflictingLeg){
		this.forLeg = forLeg;
		this.conflictingLeg = conflictingLeg;
	}
}
