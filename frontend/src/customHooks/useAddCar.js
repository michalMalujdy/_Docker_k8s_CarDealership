import {useGetSettings} from "./useGetSettings";

export const useAddCar = (car) => {
    const useAddCar = async () => {
        const {getBaseUrl} = useGetSettings();

        await fetch(`${getBaseUrl()}/cars`, {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(car)
        });
    };

    return { useAddCar };
}