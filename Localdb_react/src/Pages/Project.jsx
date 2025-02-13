import { useState, useEffect } from "react";
import * as React from "react";
import Table from "@mui/material/Table";
import TableBody from "@mui/material/TableBody";
import TableCell from "@mui/material/TableCell";
import TableContainer from "@mui/material/TableContainer";
import TableHead from "@mui/material/TableHead";
import TableRow from "@mui/material/TableRow";
import Paper from "@mui/material/Paper";
import Box from "@mui/material/Box";
import DeleteForeverRoundedIcon from "@mui/icons-material/DeleteForeverRounded";
import InputLabel from "@mui/material/InputLabel";
import Button from "@mui/material/Button";
import MenuItem from "@mui/material/MenuItem";
import FormControl from "@mui/material/FormControl";
import Select from "@mui/material/Select";
import TextField from "@mui/material/TextField";
import { Description } from "@mui/icons-material";
import Snackbar from "@mui/material/Snackbar";
import Alert from "@mui/material/Alert";
import EditNoteIcon from "@mui/icons-material/EditNote";
import "./Style.css";

function Project() {
  //GET

  const [getrole, setGetrole] = useState([]);
  const fetchrole = async () => {
    try {
      const response = await fetch("https://localhost:7132/api/role");
      const res = await response.json();
      setGetrole(res);
    } catch (error) {
      console.log(error);
    }
  };

  const [getcustomer, setGetcustomer] = useState([]);
  const fetchcustomer = async () => {
    try {
      const response = await fetch("https://localhost:7132/api/customer");
      const res = await response.json();
      setGetcustomer(res);
    } catch (error) {
      console.log(error);
    }
  };

  const [getemployee, setGetemployee] = useState([]);
  const fetchemployee = async () => {
    try {
      const response = await fetch("https://localhost:7132/api/employee");
      const res = await response.json();
      setGetemployee(res);
    } catch (error) {
      console.log(error);
    }
  };

  const [getorder, setGetorder] = useState([]);
  const fetchorder = async () => {
    try {
      const response = await fetch("https://localhost:7132/api/order");
      const res = await response.json();
      setGetorder(res);
    } catch (error) {
      console.log(error);
    }
  };

  const [box, setBox] = useState([]);
  const fetchdata = async () => {
    try {
      const response = await fetch("https://localhost:7132/api/project");
      const res = await response.json();
      setBox(res);
    } catch (error) {
      console.log(error);
    }
  };

  useEffect(() => {
    fetchrole();
    fetchorder();
    fetchemployee();
    fetchcustomer();
    fetchdata();
  }, []);

  //POST

  const [customer, setCustomer] = React.useState("");
  const [employee, setEmployee] = React.useState("");
  const [order, setOrder] = React.useState("");

  const handleCustomerChange = (event) => {
    setCustomer(event.target.value);
  };

  const handleEmployeeChange = (event) => {
    setEmployee(event.target.value);
  };

  const handleOrderChange = (event) => {
    setOrder(event.target.value);
  };

  const [projectname, setProjectName] = useState("");
  const [projectdescription, setProjectDescription] = useState("");
  const [Status, setStatus] = useState("");
  const [startdate, setStartDate] = useState("");
  const [enddate, setEndDate] = useState("");
  const [selectedProject, setSelectedProject] = useState(null);

  const handleSubmit = async () => {
    const data = {
      projectname,
      projectdescription,
      Status,
      startdate,
      enddate,
      customerId: customer,
      employeeId: employee,
      orderId: order,
    };
    setProjectName("");
    setProjectDescription("");
    setStatus("");
    setStartDate("");
    setEndDate("");
    setOrder("");
    setEmployee("");
    setCustomer("");

    try {
      const response = await fetch("https://localhost:7132/api/project", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(data),
      });

      if (response.ok) {
        console.log("Data sent successfully");
      } else {
        console.error("Something went wrong");
      }
      fetchdata();
    } catch (error) {
      console.error("Error during fetch:", error);
    }
  };

  //DELETE
  const deletebutton = async (id) => {
    try {
      const respsone = await fetch(`https://localhost:7132/api/project/${id}`, {
        method: "DELETE",
      }).then((response) => {
        if (!response.ok) {
          throw new Error("Something went wrong");
        }
      });
      fetchdata();
    } catch (error) {
      console.log(error);
    }
  };

  //UPDATE
  const updatebutton = (contact) => {
    setSelectedProject(contact);
    setProjectName(contact.projectName);
    setProjectDescription(contact.description);
    setStatus(contact.status);
    setStartDate(contact.startdate);
    setEndDate(contact.enddate);
    setCustomer(contact.customer.id);
    setEmployee(contact.employee.id);
    setOrder(contact.order.id);
  };

  const handleUpdate = async () => {
    if (!selectedProject) return;

    const data = {
      id: selectedProject.id,
      projectName: projectname,
      description: projectdescription,
      status: Status,
      startdate: startdate,
      enddate: enddate,
      customerId: customer,
      customer: selectedProject.customer,
      name: selectedProject.customer.name,
      contact: selectedProject.customer.contactId,
      contact: selectedProject.customer.contact,
      firstName: selectedProject.customer.contact.firstName,
      lastName: selectedProject.customer.contact.lastName,
      email: selectedProject.customer.contact.email,
      phoneNumber: selectedProject.customer.contact.phoneNumber,
      employeeId: employee,
      employee: selectedProject.employee,
      firstName: selectedProject.employee.firstName,
      lastName: selectedProject.employee.lastName,
      roleId: selectedProject.employee.roleId,
      role: selectedProject.employee.role,
      roleName: selectedProject.employee.role.roleName,
      orderId: order,
      order: selectedProject.order,
      orderName: selectedProject.order.orderName,
      price: selectedProject.order.price,
    };
    console.log(data);
    try {
      const response = await fetch(
        `https://localhost:7132/api/project/${selectedProject.id}`,
        {
          method: "PUT",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify(data),
        }
      );

      if (response.ok) {
        console.log("Data updated successfully");
        handleClick("Data updated successfully");
        setSelectedProject(null);
        setProjectName("");
        setProjectDescription("");
        setStatus("");
        setStartDate("");
        setEndDate("");
        setOrder("");
        setEmployee("");
        setCustomer("");
      } else {
        handleClick("Something went wrong");
      }
      fetchdata();
    } catch (error) {
      console.error("Error during fetch:", error);
      handleClick("Error during fetch");
    }
  };

  //SNACKBAR

  const [open, setOpen] = React.useState(false);
  const [snackbarMessage, setSnackbarMessage] = useState("");

  const handleClick = (message) => {
    setSnackbarMessage(message);
    setOpen(true);
  };

  const handleClose = (event, reason) => {
    if (reason === "clickaway") {
      return;
    }

    setOpen(false);
  };

  return (
    <TableContainer component={Paper} sx={{ marginTop: 3, padding: 3 }}>
      <Table sx={{ minWidth: 650 }} aria-label="simple table">
        <TableHead className="tablehead">
          <TableRow>
            <TableCell>Project Name</TableCell>
            <TableCell align="left">Project Description</TableCell>
            <TableCell align="left">Status</TableCell>
            <TableCell align="left">Start Date</TableCell>
            <TableCell align="left">End Date</TableCell>
            <TableCell align="left">Customer</TableCell>
            <TableCell align="left">Employee</TableCell>
            <TableCell align="left">Order</TableCell>
            <TableCell align="center">Edit</TableCell>
            <TableCell align="center">Delete</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {box.map((row) => (
            <TableRow
              key={row.id}
              sx={{ "&:last-child td, &:last-child th": { border: 0 } }}
            >
              <TableCell component="th" scope="row">
                {row.projectName}
              </TableCell>
              <TableCell align="left">{row.description}</TableCell>
              <TableCell align="left">{row.status}</TableCell>
              <TableCell align="left">{row.startdate}</TableCell>
              <TableCell align="left">{row.enddate}</TableCell>
              <TableCell align="left">{row.customer.name}</TableCell>
              <TableCell align="left">
                {row.employee.firstName} - {row.employee.role.roleName}
              </TableCell>
              <TableCell align="left">{row.order.orderName}</TableCell>
              <TableCell align="center">
                <Button onClick={() => updatebutton(row)}>
                  <EditNoteIcon />
                </Button>
              </TableCell>
              <TableCell align="center">
                <Button onClick={() => deletebutton(row.id)}>
                  <DeleteForeverRoundedIcon />
                </Button>
              </TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
      <Box
        component="form"
        sx={{ "& > :not(style)": { m: 1, width: "25ch" } }}
        noValidate
        autoComplete="off"
      >
        <div className="form">
          <TextField
            id="ProjectName"
            label="Project Name"
            variant="standard"
            value={projectname}
            onChange={(e) => setProjectName(e.target.value)}
          />
          <TextField
            id="ProjectDescription"
            label="Project Description"
            variant="standard"
            value={projectdescription}
            onChange={(e) => setProjectDescription(e.target.value)}
          />
          <TextField
            id="status"
            label="Status"
            variant="standard"
            value={Status}
            onChange={(e) => setStatus(e.target.value)}
          />
          <TextField
            id="StartDate"
            label="Start Date"
            variant="standard"
            value={startdate}
            onChange={(e) => setStartDate(e.target.value)}
          />
          <TextField
            id="EndDate"
            label="End Date"
            variant="standard"
            value={enddate}
            onChange={(e) => setEndDate(e.target.value)}
          />
          <FormControl variant="standard" sx={{ m: 0, minWidth: 140 }}>
            <InputLabel id="demo-simple-select-standard-label">
              Customer
            </InputLabel>
            <Select
              labelId="demo-simple-select-standard-label"
              id="demo-simple-select-standard"
              value={customer}
              onChange={handleCustomerChange}
              label="Role"
            >
              {getcustomer.map((row) => (
                <MenuItem key={row.id} value={row.id}>
                  {row.name}
                </MenuItem>
              ))}
            </Select>
          </FormControl>
          <FormControl variant="standard" sx={{ m: 0, minWidth: 140 }}>
            <InputLabel id="demo-simple-select-standard-label">
              Employee
            </InputLabel>
            <Select
              labelId="demo-simple-select-standard-label"
              id="demo-simple-select-standard"
              value={employee}
              onChange={handleEmployeeChange}
              label="Role"
            >
              {getemployee.map((emp, index) => {
                const role = getrole.find((r) => r.id === emp.role.id);
                return (
                  <MenuItem key={`${emp.id}-${index}`} value={emp.id}>
                    {emp.firstName} - {emp.role.roleName}
                  </MenuItem>
                );
              })}
            </Select>
          </FormControl>
          <FormControl variant="standard" sx={{ m: 0, minWidth: 140 }}>
            <InputLabel id="demo-simple-select-standard-label">
              Order
            </InputLabel>
            <Select
              labelId="demo-simple-select-standard-label"
              id="demo-simple-select-standard"
              value={order}
              onChange={handleOrderChange}
              label="Role"
            >
              {getorder.map((ord, index) => (
                <MenuItem key={`${ord.id}-${index}`} value={ord.id}>
                  {ord.orderName}
                </MenuItem>
              ))}
            </Select>
          </FormControl>
          <Button
            sx={{ m: 2 }}
            variant="contained"
            onClick={selectedProject ? handleUpdate : handleSubmit}
          >
            {selectedProject ? "Update" : "Submit"}
          </Button>
          <Snackbar open={open} autoHideDuration={4000} onClose={handleClose}>
            <Alert
              onClose={handleClose}
              severity="success"
              variant="filled"
              sx={{ width: "100%" }}
            >
              {snackbarMessage}
            </Alert>
          </Snackbar>
        </div>
      </Box>
    </TableContainer>
  );
}

export default Project;
