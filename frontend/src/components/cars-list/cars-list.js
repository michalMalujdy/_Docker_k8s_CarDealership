import React, {useEffect, useState} from "react";
import { Card } from 'antd';
import './cars-list.css';

const CarsList = ({shouldRefetchList, setShouldRefetchList}) => {
    const [cars, setCars] = useState([]);

    useEffect(async () => {
        await fetchCarsList();
    }, []);

    useEffect(async () => {
        if (shouldRefetchList) {
            await fetchCarsList();
            setShouldRefetchList(true);
        }
    }, [shouldRefetchList]);

    const fetchCarsList = async () => {
        console.log()
        const response = await fetch(`${process.env.REACT_APP_API_BASE_URL}/cars/list`);
        setCars(await response.json());
    }

    return (
        <div className="cars-list">
            {
                cars.map(car =>
                <Card title={`${car.make} ${car.model}`} key={car.id} className='cars-list_card'>
                    <p>Registration: {car.registrationNumber}</p>
                </Card>
            )}
        </div>
    );

};

export default CarsList;