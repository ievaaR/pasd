import React, { useEffect, useState } from 'react'
import axios from 'axios';
import 'bootstrap/dist/css/bootstrap.min.css';
import Button from 'react-bootstrap/Button';
import Card from 'react-bootstrap/Card';
import { MDBContainer } from 'mdb-react-ui-kit';


export const Order = () => {
    const [ord, getOrders] = useState('');

    //Loads data when  the page is loaded
    useEffect(()=> {
        getAllOrders();
    }, []);

    //sends a @GET request to API
    const getAllOrders = () => {
    axios.get('https://pasd-webshop-api.onrender.com/api/order/', {
        headers: {
            'accept': 'application/json',
            'x-api-key': '4sqmKzToVkUoTsVfze4X'
        }
    }).then(res => {
        const allOrders = res.data.orders;
        getOrders(allOrders);
    });
    }
    
    
    function Order(props) {
        //console.log(props.orders)
        const {menu, orders} = props;
        //console.log(orders.length);
        if(orders.length > 0) {
            return(
                orders.map((order, index) => {
                    console.log(order);
                
                    return ( 
                        <div className="p-2 bg-light border">
                        <Card className = "mx-auto" style={{ width: '18rem' }}>
                            <Card.Body>
                                <Card.Title>Id: {order.id}</Card.Title>
                                <Card.Subtitle className="mb-2 text-muted">Date: {order.send_date}</Card.Subtitle>
                                <Card.Text>
                                x: {order.x_in_mm}mm y: {order.y_in_mm}mm
                                </Card.Text>
                                <Card.Text>
                                Sender: {order.sender_info.name}
                                </Card.Text>
                                <Card.Text>
                                Address: {order.sender_info.street_and_number} {order.sender_info.zipcode}
                                </Card.Text>
                                <Card.Text>
                                Receiver: {order.receiver_info.street_and_number} {order.sender_info.zipcode}
                                </Card.Text>
                                <Card.Link href="/offer">Post an offer</Card.Link>
                                <Card.Link href="/map">Check on the map</Card.Link>
                            </Card.Body>
                        </Card> 
                        </div>
                    )
                })
            )
        } else {
            return <h3>Loading...</h3>
        }
    }

    return (
        <div className="mx-auto">
            <Order orders = {ord} />
        </div>     
    )
}
