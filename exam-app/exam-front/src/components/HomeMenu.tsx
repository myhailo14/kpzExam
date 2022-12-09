import { PrimaryButton, Stack } from "@fluentui/react";
import { useNavigate } from "react-router-dom";

const HomeMenu: React.FunctionComponent = () => {

  const navigate = useNavigate();

  return (<div>
    <Stack>
      <PrimaryButton onClick={() => { navigate('patients') }}>View Patients</PrimaryButton>
      <PrimaryButton onClick={() => { navigate('add-patient') }}>Add Patient</PrimaryButton>
      <PrimaryButton onClick={() => { navigate('add-history') }}>Add Medical History</PrimaryButton>
    </Stack>

  </div>);
}
export default HomeMenu;