import { useState } from "react";

const TrafficLight = ({ initialState, onStateUpdated }) => {
    const [state, setState] = useState(initialState);

    const redActive = state == 'red';
    const orangeActive = state == 'orange';
    const greenActive = state == 'green';

    const updateState = newState => {
        setState(newState);
        if (onStateUpdated !== undefined) onStateUpdated(newState);
    }

    return (
        <div className='trafficlight-container'>
            <div 
                className={`trafficlight-pill trafficlight-red ${redActive ? 'active' : ''}`}
                onClick={ () => updateState('red') }/>
            <div 
                className={`trafficlight-pill trafficlight-orange ${orangeActive ? 'active' : ''}`}
                onClick={ () => updateState('orange') }/>
            <div 
                className={`trafficlight-pill trafficlight-green ${greenActive ? 'active' : ''}`}
                onClick={ () => updateState('green') }/>
        </div>
    );
};

export default TrafficLight;