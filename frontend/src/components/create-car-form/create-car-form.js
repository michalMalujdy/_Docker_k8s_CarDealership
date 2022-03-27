import React from "react";
import { Form, Input, Button } from 'antd';
import './create-car-form.css';

class CreateCarForm extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            make: '',
            model: '',
            registrationNumber: '',
            isLoading: false
        };
    }

    render() {
        return (
            <Form className="create-car-form">
                <Form.Item label="Make">
                    <Input placeholder="E.g. Ford" onInput={this.setMake} />
                </Form.Item>
                <Form.Item label="Model">
                    <Input placeholder="E.g. Mondeo" onInput={this.setModel} />
                </Form.Item>
                <Form.Item label="RegistrationNumber">
                    <Input placeholder="E.g. KLI 213064" onInput={this.setRegistrationNumber} />
                </Form.Item>
                <Form.Item>
                    <Button type="primary" htmlType="submit" onClick={this.onSubmit} loading={this.state.isLoading}>Create car</Button>
                </Form.Item>
            </Form>
        );
    }

    setMake = (event) => {
        this.setState({
            ...this.state,
            make: event.target.value
        });
    }

    setModel = (event) => {
        this.setState({
            ...this.state,
            model: event.target.value
        });
    }

    setRegistrationNumber = (event) => {
        this.setState({
            ...this.state,
            registrationNumber: event.target.value
        });
    }

    onSubmit = async () => {
        this.setState({
            ...this.state,
            isLoading: true
        });

        await fetch('http://localhost:5558/cars', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(this.state)
        });

        this.props.setRefetchList(true);

        this.setState({
            ...this.state,
            isLoading: false
        });
    }
}

export default CreateCarForm;