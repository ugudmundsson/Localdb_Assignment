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
import Button from "@mui/material/Button";
import DeleteForeverRoundedIcon from "@mui/icons-material/DeleteForeverRounded";
import InputLabel from "@mui/material/InputLabel";
import MenuItem from "@mui/material/MenuItem";
import FormControl from "@mui/material/FormControl";
import Select from "@mui/material/Select";
import Alert from "@mui/material/Alert";
import Snackbar from "@mui/material/Snackbar";
import EditNoteIcon from "@mui/icons-material/EditNote";
import "./Style.css";

function Employee() {
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

  const [box, setBox] = useState([]);
  const fetchdata = async () => {
    try {
      const response = await fetch("https://localhost:7132/api/employee");
      const res = await response.json();
      setBox(res);
    } catch (error) {
      console.log(error);
    }
  };

  useEffect(() => {
    fetchrole();
    fetchdata();
  }, []);

  //POST

  const [role, setRole] = React.useState("");

  const handleChange = (event) => {
    setRole(event.target.value);
  };

  const [firstName, setFirstname] = useState("");
  const [lastName, setLastname] = useState("");
  const [selectedEmployee, setSelectedEmployee] = useState(null);

  const handleSubmit = async () => {
    const data = {
      firstName,
      lastName,
      roleId: role,
    };
    setFirstname("");
    setLastname("");
    setRole("");

    try {
      const response = await fetch("https://localhost:7132/api/employee", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(data),
      });

      if (response.ok) {
        console.log("Data sent successfully");
        handleClick("Employee was successfullu created!");
      } else {
        console.error("Something went wrong");
      }
      fetchdata();
    } catch (error) {
      console.error("Error during fetch:", error);
    }
  };

  //UPDATE
  const updatebutton = (employee) => {
    setSelectedEmployee(employee);
    setFirstname(employee.firstName);
    setLastname(employee.lastName);
    setRole(employee.roleId);
  };

  const handleUpdate = async () => {
    if (!selectedEmployee) return;

    const data = {
      id: selectedEmployee.id,
      firstName: firstName,
      lastName: lastName,
      roleId: role,
      role: selectedEmployee.role,
      roleName: selectedEmployee.role.roleName,
    };

    try {
      const response = await fetch(
        `https://localhost:7132/api/employee/${selectedEmployee.id}`,
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
        setSelectedEmployee(null);
        setFirstname("");
        setLastname("");
        setRole("");
      } else {
        handleClick("Something went wrong");
      }
      fetchdata();
    } catch (error) {
      console.error("Error during fetch:", error);
      handleClick("Error during fetch");
    }
  };

  //DELETE
  const deletebutton = async (id) => {
    try {
      const respsone = await fetch(
        `https://localhost:7132/api/employee/${id}`,
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
      <Table sx={{ minWidth: 500 }} aria-label="simple table">
        <TableHead className="tablehead">
          <TableRow>
            <TableCell>Firstname</TableCell>
            <TableCell align="left">Lastname</TableCell>
            <TableCell align="left">Role</TableCell>
            <TableCell align="right">Edit</TableCell>
            <TableCell align="left">Delete</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {box.map((row) => (
            <TableRow
              key={row.id}
              sx={{ "&:last-child td, &:last-child th": { border: 0 } }}
            >
              <TableCell component="th" scope="row">
                {row.firstName}
              </TableCell>
              <TableCell align="left">{row.lastName}</TableCell>
              <TableCell align="left">{row.role.roleName}</TableCell>
              <TableCell align="right">
                <Button onClick={() => updatebutton(row)}>
                  <EditNoteIcon />
                </Button>
              </TableCell>
              <TableCell align="left">
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
            id="firstname"
            label="Firstname"
            variant="standard"
            value={firstName}
            onChange={(e) => setFirstname(e.target.value)}
          />
          <TextField
            id="lastname"
            label="Lastname"
            variant="standard"
            value={lastName}
            onChange={(e) => setLastname(e.target.value)}
          />
          <FormControl variant="standard" sx={{ minWidth: 140 }}>
            <InputLabel id="demo-simple-select-standard-label">
              Role's
            </InputLabel>
            <Select
              labelId="demo-simple-select-standard-label"
              id="demo-simple-select-standard"
              value={role}
              onChange={handleChange}
              label="Role"
            >
              {getrole.map((row) => (
                <MenuItem key={row.id} value={row.id}>
                  {row.roleName}
                </MenuItem>
              ))}
            </Select>
          </FormControl>
          <Button
            sx={{ m: 2 }}
            variant="contained"
            onClick={selectedEmployee ? handleUpdate : handleSubmit}
          >
            {selectedEmployee ? "Update" : "Submit"}
          </Button>
          <Snackbar open={open} autoHideDuration={4000} onClose={handleClose}>
            <Alert
              onClose={handleClose}
              severity="success"
              variant="filled"
              sx={{ width: "100%" }}
            >
              Employee was Successfully Created!
            </Alert>
          </Snackbar>
        </div>
      </Box>
    </TableContainer>
  );
}

export default Employee;
