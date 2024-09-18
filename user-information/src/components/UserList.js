import React, { useState, useEffect } from 'react';
import { fetchUsers, deleteUserById } from '../services/userService'; // Ensure deleteUserById is imported
import UserCardList from './UserCardList';

const UserList = () => {
    const [users, setUsers] = useState([]);

    useEffect(() => {
        const getUsers = async () => {
            try {
                const fetchedUsers = await fetchUsers();
                setUsers(fetchedUsers);
            } catch (error) {
                console.error('Error fetching users:', error);
            }
        };

        getUsers();
    }, []);

    const handleDelete = async (id) => {
        try {
            await deleteUserById(id);
            alert('User deleted successfully!');
            setUsers(users.filter(user => user.id !== id)); // Update state to remove deleted user
        } catch (error) {
            console.error('Error deleting user:', error);
            alert('Failed to delete user. Please try again.');
        }
    };

    return (
        <div className="container mt-4">
            <h2>Users List</h2>
            <div className="row">
                {users.map(user => (
                    <UserCardList 
                        key={user.id} 
                        user={user} 
                        onDelete={handleDelete} // Pass the onDelete function
                    />
                ))}
            </div>
        </div>
    );
};

export default UserList;
