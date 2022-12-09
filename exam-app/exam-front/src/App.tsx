import { PrimaryButton, registerIcons } from '@fluentui/react';
import React from 'react';
import { Routes, useNavigate } from 'react-router';
import { Route } from 'react-router-dom';
import './App.css';
import AddHistoryForm from './components/AddHistoryForm';
import AddPatientForm from './components/AddPatientForm';
import HomeMenu from './components/HomeMenu';
import PatientTable from './components/PatientsTable';

const App: React.FunctionComponent = () => {

  const navigate = useNavigate();

  return (
    <div>
      <Routes>
        <Route path='/' element={<HomeMenu />}></Route>
        <Route path='/patients' element={<PatientTable />}></Route>
        <Route path='/add-patient' element={<AddPatientForm />}></Route>
        <Route path='/add-history' element={<AddHistoryForm />}></Route>
      </Routes>
    </div>
  );
}

export default App;
