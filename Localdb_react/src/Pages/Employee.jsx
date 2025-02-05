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

function Employee() {
  //GET

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
    fetchdata();
  }, ["https://localhost:7132/api/employee"]);

  //POST

  const [firstname, setFirstname] = useState("");
  const [lastname, setLastname] = useState("");

  const handleSubmit = async () => {
    const data = {
      firstname,
      lastname,
    };
    setFirstname("");
    setLastname("");

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
      } else {
        console.error("Something went wrong");
      }
      fetchdata();
    } catch (error) {
      console.error("Error during fetch:", error);
    }
  };
  const [age, setAge] = React.useState("");

  const handleChange = (event) => {
    setAge(event.target.value);
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

  return (
    <TableContainer component={Paper}>
      Employee's
      <Table sx={{ minWidth: 500 }} aria-label="simple table">
        <TableHead>
          <TableRow>
            <TableCell>Firstname</TableCell>
            <TableCell align="left">Lastname</TableCell>
            <TableCell align="left">Role</TableCell>
            <TableCell align="right">Delete</TableCell>
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
              <TableCell align="left">{row.roleId}</TableCell>
              <TableCell align="right">
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
        <div>
          <TextField
            id="firstname"
            label="Firstname"
            variant="standard"
            value={firstname}
            onChange={(e) => setFirstname(e.target.value)}
          />
          <TextField
            id="lastname"
            label="Lastname"
            variant="standard"
            value={lastname}
            onChange={(e) => setLastname(e.target.value)}
          />
          <FormControl variant="standard" sx={{ m: 1, minWidth: 120 }}>
            <InputLabel id="demo-simple-select-standard-label">
              Role's
            </InputLabel>
            <Select
              labelId="demo-simple-select-standard-label"
              id="demo-simple-select-standard"
              value={age}
              onChange={handleChange}
              label="Age"
            >
              <MenuItem value="">
                <em>None</em>
              </MenuItem>
            </Select>
          </FormControl>
          <Button variant="contained" onClick={handleSubmit}>
            Submit
          </Button>
        </div>
      </Box>
    </TableContainer>
  );
}

export default Employee;
