import logo from '../../logo.svg';
import './App.css';
import Cars from "../cars/Cars";

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
      </header>
      <Cars/>
    </div>
  );
}

export default App;
