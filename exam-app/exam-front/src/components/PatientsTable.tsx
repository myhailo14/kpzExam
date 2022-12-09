import { DefaultButton, DetailsList, IColumn, PrimaryButton } from '@fluentui/react';
import { List } from '@fluentui/react/lib/List';
import React, { useEffect, useState } from 'react';
import { useNavigate, useSearchParams } from 'react-router-dom';
import { IMedicalHistory } from './AddHistoryForm';


export const API_URL = "http://localhost:5016/api";

export interface IPatient {
  id: String,
  name: String,
  surname: String,
  birthday: Date
}

const PatientTable: React.FunctionComponent = () => {
  const [patients, setPatients] = useState<IPatient[]>();
  const [histories, setHistories] = useState<IMedicalHistory[]>();

  const getAllPatients = () => {
    fetch(API_URL + '/Patients/all')
      .then(response => response.json())
      .then(response => {
        let raw: any = response;
        let patientList = raw as IPatient[];
        console.log(patientList);
        setPatients(patientList);
      })
  }

  useEffect(() => {
   getAllPatients();
  }, []);

  function getDateAsString(birthday: Date): React.ReactNode {
    let newDate = new Date(birthday);
    return newDate.toISOString();
  }

  const deletePatient = (id: String) => {
    fetch(API_URL + '/Patients/' + id, {
      method: "DELETE"
    }).then(res => console.log(res.status))
    getAllPatients();
  }

  const deleteHistory = (id: String) => {
    fetch(API_URL + '/MedicalHistories/' + id, {
      method: "DELETE"
    }).then(res => console.log(res.status))
    getPatientHistories(id);
  }


  const getPatientHistories = (id: String) => {
    fetch(API_URL + '/MedicalHistories/patient/'+ id)
    .then(response => response.json())
    .then(response => {
      let raw: any = response;
      let historiesList = raw as IMedicalHistory[];
      console.log(historiesList);
      setHistories(historiesList);
    })
  }

  return (
    <>
      <table>
        <thead>
          <th>Patient name</th>
          <th>Patient surname</th>
          <th>Birthday</th>
          <th>View</th>
          <th>Delete</th>
        </thead>
        <tbody>
          {patients?.map(patient => <tr>
            <td>{patient.name}</td>
            <td>{patient.surname}</td>
            <td>{getDateAsString(patient.birthday)}</td>
            <td><DefaultButton onClick={() => {getPatientHistories(patient.id)}}>View</DefaultButton></td>
            <td><DefaultButton onClick={() => {deletePatient(patient.id)}}>Delete</DefaultButton></td>
          </tr>)}
        </tbody>
      </table>

      <table>
        <thead>        
          <th>Visit date</th>
          <th>Delete</th>
        </thead>
        <tbody>
          {histories?.map(history => <tr>
            <td>{getDateAsString(history.visitTime)}</td>
            <td><DefaultButton onClick={() => {deleteHistory(history.id)}}>Delete</DefaultButton></td>
          </tr>)}
        </tbody>
      </table>
    </>
  );
}

export default PatientTable;