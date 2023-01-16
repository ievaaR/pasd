import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';

import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import { BrowserRouter, Routes, Route, Link} from 'react-router-dom';
import {Home} from './components/Home';
import {Order} from './components/Order';
import {Delivery} from './components/Delivery';
import {Map} from './components/Map';
import {Pay} from './components/Pay';
import {Surprise} from './components/Surprise';
import {Offer} from './components/Offer';


function App() {
  return (
    <BrowserRouter>
    <div>
    <> 
      <Navbar bg="dark" variant="dark">
        <Container>
          <Navbar.Brand as={Link} to ="/">Home</Navbar.Brand>
          <Nav className="me-auto">
            <Nav.Link as={Link} to ="/delivery">Delivery</Nav.Link>
            <Nav.Link as={Link} to ="/order">Order</Nav.Link>
            <Nav.Link as={Link} to ="/map">Map</Nav.Link>
            <Nav.Link as={Link} to ="/pay">Pay</Nav.Link>
            <Nav.Link as={Link} to ="/surprise">Surprise</Nav.Link>
          </Nav>
        </Container>
      </Navbar>
    </>
    <>
      <Routes>
        <Route path="/" element={<Home/>}/>
        <Route path="/order" element={<Order/>}/>
        <Route path="/delivery" element={<Delivery/>}/>
        <Route path="/map" element={<Map/>}/>
        <Route path="/pay" element={<Pay/>}/>
        <Route path="/surprise" element={<Surprise/>}/>
        <Route path="/offer" element= {<Offer/>}/> 
      </Routes>
    </>
    </div>
    </BrowserRouter> 
  );
}


export default App;

