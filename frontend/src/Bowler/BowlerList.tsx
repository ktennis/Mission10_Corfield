import { useEffect, useState } from 'react';
import { Bowler } from '../types/Bowler';

//get data
function BowlerList() {
  const [bowlerData, setBowlerData] = useState<Bowler[]>([]);

  useEffect(() => {
    const fetchBowlerData = async () => {
      const rsp = await fetch('http://localhost:5266/Bowler');
      const b = await rsp.json();
      setBowlerData(b);
    };

    fetchBowlerData();
  }, []);

  //filter data for sharks and marlins
  const filteredBowlerData = bowlerData.filter(
    (bowler) =>
      bowler.team.teamName === 'Sharks' || bowler.team.teamName === 'Marlins',
  );

  //Table for all bowler info
  return (
    <div>
      <table className="table table-bordered">
        <thead>
          <tr>
            <th>Bowler Name</th>
            <th>Team Name</th>
            <th>Address</th>
            <th>City</th>
            <th>State</th>
            <th>Zip</th>
            <th>Phone</th>
          </tr>
        </thead>
        <tbody>
          {filteredBowlerData.map((f) => (
            <tr key={f.bowlerId}>
              <td>
                {f.bowlerFirstName} {f.bowlerMiddleInit} {f.bowlerLastName}
              </td>
              <td>{f.team.teamName}</td>
              <td>{f.bowlerAddress}</td>
              <td>{f.bowlerCity}</td>
              <td>{f.bowlerState}</td>
              <td>{f.bowlerZip}</td>
              <td>{f.bowlerPhoneNumber}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default BowlerList;
