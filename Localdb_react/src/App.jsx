import { BrowserRouter, Routes, Route } from "react-router-dom";
import Home from "./Home";
import Nav from "./Pages/Navbar";
import Contact from "./Pages/Contact";
import Customer from "./Pages/Customer";
import Employee from "./Pages/Employee";
import Project from "./Pages/Project";
import Order from "./Pages/Order";
import Role from "./Pages/Role";

function App() {
  return (
    <BrowserRouter>
      <Nav />
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/project" element={<Project />} />
        <Route path="/contact" element={<Contact />} />
        <Route path="/employee" element={<Employee />} />
        <Route path="/customer" element={<Customer />} />
        <Route path="/order" element={<Order />} />
        <Route path="/role" element={<Role />} />
      </Routes>
    </BrowserRouter>
  );
}
export default App;
