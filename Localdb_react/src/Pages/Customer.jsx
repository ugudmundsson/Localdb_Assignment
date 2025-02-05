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

  const [age, setAge] = React.useState("");

  const handleChange = (event) => {
    setAge(event.target.value);
  };

  const [name, setName] = useState("");

  const handleSubmit = async () => {
    const data = {
      name,
      contactId: age,
    };
    setAge("");
    setName("");

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

  return (
    <TableContainer component={Paper}>
      Customer's
      <Table sx={{ minWidth: 650 }} aria-label="simple table">
        <TableHead>
          <TableRow>
            <TableCell>Company Name</TableCell>
            <TableCell align="right">Contact Person</TableCell>
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
                {row.name}
              </TableCell>
              <TableCell align="right">{row.contactId}</TableCell>
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
              value={age}
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

          <Button variant="contained" onClick={handleSubmit}>
            Submit
          </Button>
        </div>
      </Box>
    </TableContainer>
  );
}

export default Customer;
