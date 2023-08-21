import React, { useState } from "react";
import './LoginForm.css';


const LoginForm = (props) => {

const [username,setUsername] = useState('');
const [password,setPassword] = useState('');

const [loginUsers, setLoginUsers] = useState([]); // Use a state variable to store login users

	const handleSubmit = (event) =>{
		
		event.preventDefault();
		props.onSubmit({
			login: username,
			password: password,
		});

		setLoginUsers([...loginUsers, username]); // Update the state with the new login
		
		//console.log(this);
	}

	return (
		
		<form className="form">
			<h1>Login</h1>
			<label htmlFor="name">Name</label>
			<input type="text" onChange={e => setUsername(e.target.value)}  value={username} id="name" />
			<label htmlFor="password">Password</label>
			<input type="password" onChange={e => setPassword(e.target.value)}   value={password} id="password" />
			<button type="submit" onClick={handleSubmit}>Continue</button>

			{
				loginUsers.map((usr,indx)=>{
					return (
						<a  key={indx} >User:{usr} - Attempted Login</a>
					);
					
					

				})
			}
		</form>
	
	)
}

export default LoginForm;