import React from 'react';
import './App.css';
import Header from './Header';
import BowlerList from './Bowler/BowlerList';

//put it together
function App() {
  return (
    <div className="App">
      <Header title="Bowling League Team Roster!" />
      <BowlerList />
    </div>
  );
}

export default App;
