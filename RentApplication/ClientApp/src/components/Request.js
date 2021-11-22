import React, { Component } from 'react';

export class Request extends Component {
    static displayName = Request.name;

    constructor(props) {
        super(props);
        this.state = { requests: [], loading: true };
    }

    componentDidMount() {
        this.populateWeatherData();
    }

    static renderForecastsTable(requests) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                <tr>
                    <th>Id</th>
                    <th>Client Id</th>
                    <th>Property Id</th>
                    <th>Is Active</th>
                </tr>
                </thead>
                <tbody>
                {requests.map(request =>
                    <tr key={request.id}>
                        <td>{request.id}</td>
                        <td>{request.clientId}</td>
                        <td>{request.propertyId}</td>
                        <td>{request.isActive}</td>
                    </tr>
                )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Request.renderForecastsTable(this.state.requests);

        return (
            <div>
                <h1 id="tabelLabel" >Weather forecast</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        );
    }

    async populateWeatherData() {
        const response = await fetch('Request');
        const data = await response.json();
        console.log(data);
        this.setState({ requests: data, loading: false });
    }
}
