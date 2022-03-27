import logo from '../../logo.svg';
import './App.css';
import CarsList from "../cars-list/cars-list";
import CreateCarForm from "../create-car-form/create-car-form";
import { Tabs } from 'antd';

function App() {
  return (
    <div className="App">
        <header className="App-header">
            <img src={logo} className="App-logo" alt="logo" />
        </header>
        <div className="App-content">
            <Tabs defaultActiveKey="1">
                <Tabs.TabPane tab="List" key="1">
                    <CarsList/>
                </Tabs.TabPane>
                <Tabs.TabPane tab="Create" key="2">
                    <CreateCarForm/>
                </Tabs.TabPane>
            </Tabs>
        </div>
    </div>
  );
}

export default App;
