import { useAppDispatch } from '../../state/hooks';
import { loggedOut } from '../../slices/MenuSlice'
import { useGoogleLogout } from 'react-google-login'
import { Button } from "reactstrap";

const clientId = '778159703392-1vbp93089n4t90eadabigdedmdti97id.apps.googleusercontent.com';

function Logout() {
    const dispatch = useAppDispatch();

    const onSuccess = () => {
        dispatch(loggedOut())
    };

    const { signOut } =
        useGoogleLogout({
            clientId: clientId,
            onLogoutSuccess: onSuccess,
        })

    return (
        <Button onClick={() => signOut()} color="primary">Quit</Button>
    );
}

export default Logout;