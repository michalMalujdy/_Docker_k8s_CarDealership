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
        const response = await fetch('https://localhost:7011/cars/list')
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