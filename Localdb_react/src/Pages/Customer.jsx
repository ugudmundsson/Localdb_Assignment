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
import TextField from "@mui/material/TextField";
import DeleteForeverRoundedIcon from "@mui/icons-material/DeleteForeverRounded";
import Button from "@mui/material/Button";
import InputLabel from "@mui/material/InputLabel";
import MenuItem from "@mui/material/MenuItem";
import FormControl from "@mui/material/FormControl";
import Select from "@mui/material/Select";
import Alert from "@mui/material/Alert";
import Snackbar from "@mui/material/Snackbar";
import EditNoteIcon from "@mui/icons-material/EditNote";
import "./Style.css";

function Customer() {
  //GET

  const [contactperson, setContactperson] = useState([]);
  const fetchcontact = async () => {
    try {
      const response = await fetch("https://localhost:7132/api/contact");
      const res = await response.json();
      setContactperson(res);
    } catch (error) {
      console.log(error);
    }
  };

  const [box, setBox] = useState([]);
  const fetchdata = async () => {
    try {
      const response = await fetch("https://localhost:7132/api/customer");
      const res = await response.json();
      setBox(res);
    } catch (error) {
      console.log(error);
    }
  };

  useEffect(() => {
    fetchcontact();
    fetchdata();
  }, []);

  //POST

  const [contact, setContact] = React.useState("");

  const handleChange = (event) => {
    setContact(event.target.value);
  };

  const [name, setName] = useState("");
  const [selectedCustomer, setSelectedCustomer] = useState(null);

  const handleSubmit = async () => {
    const data = {
      name,
      contactId: contact,
    };
    setName("");
    setContact("");

    try {
      const response = await fetch("https://localhost:7132/api/customer", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(data),
      });

      if (response.ok) {
        console.log("Data sent successfully");
        handleClick();
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
      const respsone = await fetch(
        `https://localhost:7132/api/customer/${id}`,
        {
          method: "DELETE",
        }
      ).then((response) => {
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

  const updatebutton = (customer) => {
    setSelectedCustomer(customer);
    setName(customer.name);
    setContact(customer.contactId);
  };

  const handleUpdate = async () => {
    if (!selectedCustomer) return;

    const data = {
      id: selectedCustomer.id,
      name: name,
      contactId: contact,
      contact: selectedCustomer.contact,
      firstName: selectedCustomer.contact.firstName,
      lastName: selectedCustomer.contact.lastName,
      email: selectedCustomer.contact.email,
      phoneNumber: selectedCustomer.contact.phoneNumber,
    };
    console.log(data);
    try {
      const response = await fetch(
        `https://localhost:7132/api/customer/${selectedCustomer.id}`,
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
        setSelectedCustomer(null);
        setName("");
        setContact("");
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

  const handleClick = (message) => {
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
            <TableCell>Company Name</TableCell>
            <TableCell align="left">
              Contact Person - ( Email ) - Phonenumber
            </TableCell>
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
                {row.name}
              </TableCell>
              <TableCell align="left">
                {row.contact.firstName} {row.contact.lastName} - ({" "}
                {row.contact.email} ) - {row.contact.phoneNumber}
              </TableCell>
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
            id="companyname"
            label="Company Name"
            variant="standard"
            value={name}
            onChange={(e) => setName(e.target.value)}
          />
          <FormControl variant="standard" sx={{ m: 0, minWidth: 140 }}>
            <InputLabel id="demo-simple-select-standard-label">
              Contact Person
            </InputLabel>
            <Select
              labelId="demo-simple-select-standard-label"
              id="demo-simple-select-standard"
              value={contact}
              onChange={handleChange}
              label="Role"
            >
              {contactperson.map((row) => (
                <MenuItem key={row.id} value={row.id}>
                  {row.firstName}
                </MenuItem>
              ))}
            </Select>
          </FormControl>
          <Button
            sx={{ m: 2 }}
            variant="contained"
            onClick={selectedCustomer ? handleUpdate : handleSubmit}
          >
            {selectedCustomer ? "Update" : "Submit"}
          </Button>
          <Snackbar open={open} autoHideDuration={4000} onClose={handleClose}>
            <Alert
              onClose={handleClose}
              severity="success"
              variant="filled"
              sx={{ width: "100%" }}
            >
              Customer was Successfully Created!
            </Alert>
          </Snackbar>
        </div>
      </Box>
    </TableContainer>
  );
}

export default Customer;
