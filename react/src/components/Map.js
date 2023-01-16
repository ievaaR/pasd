import React from 'react'
import {GoogleMap, useLoadScript, Marker} from '@react-google-maps/api';
import './style.css';

export function Map() {
    const {isLoaded}= useLoadScript({
        googleMapsApiKey: "AIzaSyDfiLZA7lRR8_OvaJgTp7ZstZFXB3W0grw",
    });
    
    if(!isLoaded) return <div>Loading...</div>
     
    return <div>
            <h1>Just use gps and go away</h1>
            <GoogleMap zoom={14} center={{lat: 53.21917, lng: 6.56667}} mapContainerClassName="map-container">
                <Marker position={{lat: 53.21917, lng: 6.56667}} />
            </GoogleMap>;
            
            </div>
    
}

