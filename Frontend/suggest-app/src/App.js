import React from 'react';
import logo from './logo.svg';
import './App.css';
import SuggestDropdown from './components/SuggestDropdown';

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <SuggestDropdown/>
      </header>
    </div>
  );
}

export default App;
