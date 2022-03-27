export const useAddCar = (car) => {
    const addCar = async () => {
        await fetch('http://localhost:5558/cars', {
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