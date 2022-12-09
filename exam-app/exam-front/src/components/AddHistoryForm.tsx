import { DatePicker, DocumentCard, Dropdown, IDropdownOption, PrimaryButton, Stack, TextField } from "@fluentui/react";
import { useEffect, useState } from "react";
import { text } from "stream/consumers";
import { API_URL, IPatient } from "./PatientsTable";

export interface IMedicalHistory {
  id: String,
  patientId: String,
  visitTime: Date
}

const AddHistoryForm: React.FunctionComponent = () => {

  const [visitTime, setVisitTime] = useState<Date>();
  const [patients, setPatients] = useState<IPatient[]>([]);
  const [selectedPatient, setSelectedPatient] = useState<String>();

  useEffect(() => {
    fetch(API_URL + '/Patients/all')
      .then(response => response.json())
      .then(response => {
        let raw: any = response;
        let patientList = raw as IPatient[];
        console.log(patientList);
        setPatients(patientList);
      })
      
  }, []);

  const items = patients!.map(patient => {return {key: patient.id, text: patient.name + " " + patient.surname} as IDropdownOption})

  const addHistory = () => {
    let history: IMedicalHistory = {
      id: crypto.randomUUID(),
      patientId: selectedPatient!,
      visitTime: visitTime!
    }

    fetch(API_URL + '/MedicalHistories', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(history),
    }).then(res => console.log(res.status));
  }
  return (
    <>
      <Stack>
        <DocumentCard>
          <Dropdown onChange={(e,o) => {setSelectedPatient(o!.key as String) }} label="Patient name" options={items} placeholder="Select patient"></Dropdown>
          <DatePicker onSelectDate={(d) => { setVisitTime(d!) }} label="Patient visit"></DatePicker>
          <PrimaryButton onClick={() => {addHistory()}}>Add Medical History</PrimaryButton>
        </DocumentCard>
      </Stack>
    </>
  )
}

export default AddHistoryForm;