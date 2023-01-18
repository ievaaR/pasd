import React from 'react'
import {GoogleMap, useLoadScript, Marker} from '@react-google-maps/api';
import Navbar from '../components/Navbar';

function Pay() {
    const {isLoaded}= useLoadScript({
        googleMapsApiKey: "AIzaSyDfiLZA7lRR8_OvaJgTp7ZstZFXB3W0grw",
    });
    
    if(!isLoaded) return <div>Loading...</div>
     
    return <div>
            <Navbar/>
            
            <GoogleMap zoom={14} center={{lat: 53.21917, lng: 6.56667}} mapContainerClassName="map-container">
                <Marker position={{lat: 53.21917, lng: 6.56667}} />
                <Marker position={{lat: 53.23, lng: 6.56667}} />
                <Marker position={{lat: 53.21, lng: 6.57}} />
                <Marker position={{lat: 53.17, lng: 6.55}} />
            </GoogleMap>;
            </div>
    
}

export default Pay;