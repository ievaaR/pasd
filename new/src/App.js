import logo from './logo.svg';
import './App.css';
import Navbar from "./components/Navbar"
import {Routes, Route} from "react-router-dom" 
import Home from "./routes/Home"
import History from "./routes/History"
import Map from "./routes/Map"
import Orders from "./routes/Orders"
import Pay from "./routes/Pay"
import Checking from "./routes/Checking"
import { Offer } from './routes/Offer';

function App() {
  return (
    <div className="App">
      <Routes>
        <Route path="/" element={<Home/>}/>
        <Route path="/history" element={<History/>}/>
        <Route path="/check" element={<Checking/>}/>
        <Route path="/map" element={<Map/>}/>
        <Route path="/offer" element={<><Navbar/> <Offer className="map-container"/></>}/>
        <Route path="/orders" element={<><Navbar/> <Orders/></>}/>
        <Route path="/pay" element={<Pay/>}/>
      </Routes>
     </div>
  );
}

export default App;
  