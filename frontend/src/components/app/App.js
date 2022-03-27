import logo from '../../logo.svg';
import React from "react";
import './App.css';
import CarsList from "../cars-list/cars-list";
import CreateCarForm from "../create-car-form/create-car-form";
import { Tabs } from 'antd';

class App extends React.Component {
    state = {
        shouldRefetchList: false
    };

    setRefetchList = (shouldRefetch) => {
        this.setState({
            shouldRefetchList: shouldRefetch
        });
    }

    render() {
        return (
            <div className="App">
                <header className="App-header">
                    <img src={logo} className="App-logo" alt="logo" />
                </header>
                <div className="App-content">
                    <Tabs defaultActiveKey="1">
                        <Tabs.TabPane tab="List" key="1">
                            <CarsList shouldRefetchList={this.state.shouldRefetchList} setRefetchList={this.setRefetchList} />
                        </Tabs.TabPane>
                        <Tabs.TabPane tab="Create" key="2">
                            <CreateCarForm setRefetchList={this.setRefetchList} />
                        </Tabs.TabPane>
                    </Tabs>
                </div>
            </div>
        );
    }
}

export default App;
