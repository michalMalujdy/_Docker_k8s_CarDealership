import React from "react";

class Cars extends React.Component {
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
            <div>
                <div>Make: {car.make}</div>
                <div>Model: {car.model}</div>
                <div>Registration: {car.registrationNumber}</div>
            </div>
        )
    }
}

export default Cars;