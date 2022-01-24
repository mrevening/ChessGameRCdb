import { GoogleLogout } from 'react-google-login';
import { useAppDispatch } from '../../state/hooks';
import { loggedOut } from '../menu/MenuSlice'

const clientId = '778159703392-1vbp93089n4t90eadabigdedmdti97id.apps.googleusercontent.com';

function Logout() {
    const dispatch = useAppDispatch();

    const onSuccess = () => {
        dispatch(loggedOut())
    };

    return (
        <div>
            <GoogleLogout
                clientId={clientId}
                buttonText="Logout"
                onLogoutSuccess={onSuccess}
            ></GoogleLogout>
        </div>
    );
}

export default Logout;