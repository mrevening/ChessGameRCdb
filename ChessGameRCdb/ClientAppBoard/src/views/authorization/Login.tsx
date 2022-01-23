import { GoogleLogin } from 'react-google-login';
import { refreshTokenSetup } from './utils/refreshToken';
import { useAppDispatch } from 'state/hooks'
import { loggedIn } from '../menu/MenuSlice'

const clientId = '778159703392-1vbp93089n4t90eadabigdedmdti97id.apps.googleusercontent.com';

function Login() {
    const dispatch = useAppDispatch();

    const onSuccess = (res: any) => {
        console.log('Login Success: currentUser:', res.profileObj);
        alert(
            `Logged in successfully welcome ${res.profileObj.name}. \n See console for full profile object.`
        );
        refreshTokenSetup(res);
        dispatch(loggedIn())
    };

    const onFailure = (res: any) => {
        console.log('Login failed: res:', res);
        alert(
            `Failed to login.`
        );
    };

    return (
        <div>
            <GoogleLogin
                clientId={clientId}
                buttonText="Login"
                onSuccess={onSuccess}
                onFailure={onFailure}
                cookiePolicy={'single_host_origin'}
                style={{ marginTop: '100px' }}
                isSignedIn={true}
            />
        </div>
    );
}

export default Login;