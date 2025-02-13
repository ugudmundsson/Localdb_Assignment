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
import Snackbar from "@mui/material/Snackbar";
import Alert from "@mui/material/Alert";
import EditNoteIcon from "@mui/icons-material/EditNote";
import "./Style.css";
import Typography from "@mui/material/Typography";
import Breadcrumbs from "@mui/material/Breadcrumbs";
import Link from "@mui/material/Link";

function Role() {
  //GET

  const [box, setBox] = useState([]);
  const fetchdata = async () => {
    try {
      const response = await fetch("https://localhost:7132/api/role");
      const res = await response.json();
      setBox(res);
    } catch (error) {
      console.log(error);
    }
  };

  useEffect(() => {
    fetchdata();
  }, ["https://localhost:7132/api/role"]);

  //POST

  const [roleName, setRole] = useState("");
  const [selectedRole, setSelectedRole] = useState(null);

  const handleSubmit = async () => {
    const data = {
      roleName,
    };
    setRole("");

    try {
      const response = await fetch("https://localhost:7132/api/role", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(data),
      });

      if (response.ok) {
        handleClick("Role was successfully created!");
      } else {
        handleClick("Something went wrong");
      }
      fetchdata();
    } catch (error) {
      console.error("Error during fetch:", error);
    }
  };

  //UPDATE
  const updatebutton = (contact) => {
    setSelectedRole(contact);
    setRole(contact.roleName);
  };

  const handleUpdate = async () => {
    if (!selectedRole) return;

    const data = {
      id: selectedRole.id,
      roleName: roleName,
    };

    try {
      const response = await fetch(
        `https://localhost:7132/api/role/${selectedRole.id}`,
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
        setSelectedRole(null);
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
      const respsone = await fetch(`https://localhost:7132/api/role/${id}`, {
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
      <div>
        <Breadcrumbs aria-label="breadcrumb" sx={{ marginBottom: 3 }}>
          <Link underline="hover" color="inherit" href="/">
            Home
          </Link>
          <Typography sx={{ color: "text.primary" }}>Role's</Typography>
        </Breadcrumbs>
      </div>
      <Table sx={{ minWidth: 650 }} aria-label="simple table">
        <TableHead className="tablehead">
          <TableRow>
            <TableCell>Roles</TableCell>
            <TableCell align="right">Edit </TableCell>
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
                {row.roleName}
              </TableCell>
              <TableCell align="right">
                <Button sx={{ m: 0 }} onClick={() => updatebutton(row)}>
                  <EditNoteIcon />
                </Button>
              </TableCell>
              <TableCell align="left">
                <Button sx={{ m: 0 }} onClick={() => deletebutton(row.id)}>
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
            label="Create new role"
            variant="standard"
            value={roleName}
            onChange={(e) => setRole(e.target.value)}
          />
          <Button
            sx={{ m: 2 }}
            variant="contained"
            onClick={selectedRole ? handleUpdate : handleSubmit}
          >
            {selectedRole ? "Update" : "Submit"}
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

export default Role;
