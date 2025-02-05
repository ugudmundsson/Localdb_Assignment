import { useState, useEffect } from "react";
import * as React from "react";
import Table from "@mui/material/Table";
import TableBody from "@mui/material/TableBody";
import TableCell from "@mui/material/TableCell";
import TableContainer from "@mui/material/TableContainer";
import TableHead from "@mui/material/TableHead";
import TableRow from "@mui/material/TableRow";
import Paper from "@mui/material/Paper";
import DeleteForeverRoundedIcon from "@mui/icons-material/DeleteForeverRounded";
import Button from "@mui/material/Button";

function Project() {
  const [box, setBox] = useState([]);
  useEffect(() => {
    fetch("https://localhost:7132/api/project")
      .then((res) => {
        return res.json();
      })
      .then((data) => {
        setBox(data);
        console.log(data);
      });
  }, []);

  return (
    <TableContainer component={Paper}>
      Project's
      <Table sx={{ minWidth: 650 }} aria-label="simple table">
        <TableHead>
          <TableRow>
            <TableCell>Project Name</TableCell>
            <TableCell align="right">Project Description</TableCell>
            <TableCell align="right">Status</TableCell>
            <TableCell align="right">Start Date</TableCell>
            <TableCell align="right">End Date</TableCell>
            <TableCell align="right">Customer</TableCell>
            <TableCell align="right">Employee</TableCell>
            <TableCell align="right">Order</TableCell>
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
              <TableCell align="right">{row.description}</TableCell>
              <TableCell align="right">{row.status}</TableCell>
              <TableCell align="right">{row.startdate}</TableCell>
              <TableCell align="right">{row.enddate}</TableCell>
              <TableCell align="right">{row.customId}</TableCell>
              <TableCell align="right">{row.employeeId}</TableCell>
              <TableCell align="right">{row.orderId}</TableCell>
              <TableCell align="right">
                <Button>
                  <DeleteForeverRoundedIcon />
                </Button>
              </TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </TableContainer>
  );
}

export default Project;
