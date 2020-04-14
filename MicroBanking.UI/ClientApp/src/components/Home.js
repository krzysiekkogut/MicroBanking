import React, { Component } from 'react';

export class Home extends Component {
    static displayName = Home.name;

    state = {
        sourceAccountId: 0,
        targetAccountId: 0,
        amount: 0,
    };

    render() {
        return (
            <div style={{ padding: 16 }}>
                <h1>Micro Banking</h1>
                <div>
                    <label style={{ width: 150 }} htmlFor="fromAccount">From account:</label>
                    <input
                        id="fromAccount"
                        type="number"
                        value={this.state.sourceAccountId}
                        onChange={(event) => this.setState({ sourceAccountId: parseFloat(event.target.value) })}
                    />
                </div>

                <div>
                    <label style={{ width: 150 }} htmlFor="toAccount">To account:</label>
                    <input
                        id="fromAccount"
                        type="number"
                        value={this.state.targetAccountId}
                        onChange={(event) => this.setState({ targetAccountId: parseFloat(event.target.value) })}
                    />
                </div>

                <div>
                    <label style={{ width: 150 }} htmlFor="amount">Amount:</label>
                    <input
                        id="amount"
                        type="number"
                        value={this.state.amount}
                        onChange={(event) => this.setState({ amount: parseFloat(event.target.value) })}
                    />
                </div>

                <button onClick={() => this.onSubmit()}>Transfer</button>
            </div>
        );
    }

    onSubmit() {
        fetch('/api/banking', {
            body: JSON.stringify(this.state),
            method: 'POST',
            headers: {
                'content-type': 'application/json'
            }
        }).then(
            () => { console.log('Transfer submitted.'); },
            (reason) => { console.error(reason); }
        )
    }
}
