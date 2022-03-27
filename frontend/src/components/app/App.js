import logo from '../../logo.svg';
import React, {useState} from "react";
import './App.css';
import CarsList from "../cars-list/cars-list";
import CreateCarForm from "../create-car-form/create-car-form";
import { Tabs } from 'antd';

const App = () => {
    const [shouldRefetchList, setShouldRefetchList] = useState(false);

    return (
        <div className="App">
            <header className="App-header">
                <img src={logo} className="App-logo" alt="logo" />
            </header>
            <div className="App-content">
                <Tabs defaultActiveKey="1">
                    <Tabs.TabPane tab="List" key="1">
                        <CarsList shouldRefetchList={shouldRefetchList} setShouldRefetchList={setShouldRefetchList} />
                    </Tabs.TabPane>
                    <Tabs.TabPane tab="Create" key="2">
                        <CreateCarForm setShouldRefetchList={setShouldRefetchList} />
                    </Tabs.TabPane>
                </Tabs>
            </div>
        </div>
    );
}

export default App;
