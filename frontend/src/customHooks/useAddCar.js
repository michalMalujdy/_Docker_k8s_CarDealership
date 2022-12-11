import {useGetSettings} from "./useGetSettings";

export const useAddCar = (car) => {
    const {getBaseUrl} = useGetSettings();
    const baseUrl = getBaseUrl();

    const addCar = async () => {
        await fetch(`${baseUrl}/cars`, {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(car)
        });
    };

    return { addCar };
}