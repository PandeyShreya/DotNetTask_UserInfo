
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import UserList from '../components/UserList'
import AddUser from '../components/AddUser'
import DeleteUser from '../components/DeleteUser'
import Navbar from '../components/Navbar';
import MainHome from '../home/MainHome';
import UpdateName from '../components/UpdateName';
import UserCard from '../components/UserCard'

const EndPoints = () => {
  return (
    <>
      {/* <BrowserRouter> */}
            <Navbar />
            <div className="container mt-4">
                <Routes>
                    <Route path="/" element={<MainHome/>} />
                    <Route path="/users" element={<UserList />} />
                    <Route path="/add-user" element={<AddUser />} />
                    <Route path="/delete-user" element={<DeleteUser />} />
                    <Route path="/update-name" element={<UpdateName />} />
                    <Route path="/users/:id" element={<UserCard/>}/>
                </Routes>
            </div>
        {/* </BrowserRouter> */}
    </>
  )
}

export default EndPoints
