export const useAddCar = (car) => {
    const addCar = async () => {
        await fetch(`${process.env.REACT_APP_API_BASE_URL}/cars`, {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(car)
        });
    };

    return {addCar};
}