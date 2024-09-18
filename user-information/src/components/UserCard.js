import React, { useEffect, useState } from 'react';
import { fetchUsers, fetchUsersById } from '../services/userService';
import { useParams } from 'react-router-dom';

const UserCard = () => {
    
    const {id} =useParams();
    const [user, setUsers] = useState({});

    useEffect(() => {
        const getUsers = async () => {
            try {
                const fetchedUsers = await fetchUsersById(id);
                setUsers(fetchedUsers);
                console.log(user.id)
            } catch (error) {
                console.error('Error fetching users:', error);
            }
        };

        getUsers();
    }, []);
    

    return (
        <div className="card mb-3 d-flex justify-content-center"style={{ maxWidth: '540px' }}>
            <div className="row g-0">
                <div className="col-md-8">
                    <div className="card-body">
                    <h5 className="card-title">{user.name}</h5>
                        <p className="card-text"><strong>Phone:</strong> {user.phoneNumber}</p>
                        <p className="card-text"><strong>Email:</strong> {user.emailAddress}</p>
                        <p className="card-text"><strong>Occupation:</strong> {user.occupation}</p>
                        <p className="card-text"><strong>Address:</strong> {user.residentialAddress}</p>
                        <p className="card-text"><strong>Permanent Address:</strong> {user.permanentAddress}</p>
                        <p className="card-text"><strong>Date of Birth:</strong> {new Date(user.dateOfBirth).toLocaleDateString()}</p>
                        <p className="card-text"><strong>Gender:</strong> {user.gender}</p>
                        <p className="card-text"><strong>Marital Status:</strong> {user.maritalStatus}</p>
                        <p className="card-text"><strong>Aadhar Card Number:</strong> {user.aadharCardNumber}</p>
                        <p className="card-text"><strong>PAN Number:</strong> {user.panNumber}</p>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default UserCard;
