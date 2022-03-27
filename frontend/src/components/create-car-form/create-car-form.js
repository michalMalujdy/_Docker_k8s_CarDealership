import React, {useState} from "react";
import { Form, Input, Button } from 'antd';
import './create-car-form.css';
import {useAddCar} from "../../customHooks/useAddCar";

const CreateCarForm = ({setShouldRefetchList}) => {
    const [make, setMake] = useState('');
    const [model, setModel] = useState('');
    const [registrationNumber, setRegistrationNumber] = useState('');
    const [isLoading, setIsLoading] = useState(false);
    const {addCar} = useAddCar({make, model, registrationNumber});

    const onSubmit = async () => {
        setIsLoading(true);
        await addCar();
        setShouldRefetchList(true);
        setIsLoading(false);
    }

    return (
        <Form className="create-car-form">
            <Form.Item label="Make">
                <Input placeholder="E.g. Ford" value={make} onChange={(e) => setMake(e.target.value)} />
            </Form.Item>
            <Form.Item label="Model">
                <Input placeholder="E.g. Mondeo" value={model} onChange={e => setModel(e.target.value)} />
            </Form.Item>
            <Form.Item label="RegistrationNumber">
                <Input placeholder="E.g. KLI 213064" value={registrationNumber} onChange={e => setRegistrationNumber(e.target.value)} />
            </Form.Item>
            <Form.Item>
                <Button type="primary" htmlType="submit" onClick={onSubmit} loading={isLoading}>Create car</Button>
            </Form.Item>
        </Form>
    );
};

export default CreateCarForm;