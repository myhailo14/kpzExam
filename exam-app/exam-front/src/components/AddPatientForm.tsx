import { DatePicker, DocumentCard, PrimaryButton, Stack, TextField } from "@fluentui/react";
import { useEffect, useState } from "react";
import { API_URL, IPatient } from "./PatientsTable";


const AddPatientForm: React.FunctionComponent = () => {

  const [name, setName] = useState<String>("");
  const [surname, setSurname] = useState<String>("");
  const [birthday, setBirthday] = useState<Date>();

  const addPatient = () => {
    let patient: IPatient = {
      id: crypto.randomUUID(),
      name: name,
      surname: surname,
      birthday: birthday!
    }

    fetch(API_URL + '/Patients', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(patient),
    }).then(res => console.log(res.status));
  }

  return (
    <>
    <Stack>
      <DocumentCard>
        <TextField onChange={(e, v) => { setName(v!) }} label="Patient name"></TextField>
        <TextField onChange={(e, v) => { setSurname(v!) }} label="Patient surname"></TextField>
        <DatePicker onSelectDate={(d) => { setBirthday(d!) }} label="Patients birthday"></DatePicker>
        <PrimaryButton onClick={() => { addPatient() }}>Add Patient</PrimaryButton>
      </DocumentCard>
    </Stack>
      
    </>
  )
}

export default AddPatientForm;