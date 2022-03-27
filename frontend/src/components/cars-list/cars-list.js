import React from "react";
import { Card } from 'antd';
import './cars-list.css';

class CarsList extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            cars: []
        };
    }

    async componentDidMount() {
        await this.fetchCarsList();
    }

    async componentDidUpdate() {
        if (this.props.shouldRefetchList) {
            await this.fetchCarsList();
            this.props.setRefetchList(false);
        }
    }

    async fetchCarsList() {
        console.log()
        const response = await fetch('http://localhost:5558/cars/list')
        this.setState({
            cars: await response.json()
        });
    }

    render() {
        return this.state.cars.map(car =>
            <Card title={`${car.make} ${car.model}`} key={car.id} className='cars-list_card'>
                <p>Registration: {car.registrationNumber}</p>
            </Card>
        )
    }
}

export default CarsList;