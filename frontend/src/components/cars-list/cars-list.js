import React, {useEffect, useState} from "react";
import { Card } from 'antd';
import './cars-list.css';
import {useGetSettings} from "../../customHooks/useGetSettings";

const CarsList = ({shouldRefetchList, setShouldRefetchList}) => {
    const [cars, setCars] = useState([]);
    const {getBaseUrl} = useGetSettings();

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
        const response = await fetch(`${getBaseUrl()}/cars/list`);
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