import React, { useState } from 'react';
import { updateName } from '../services/userService';

const UpdateName = () => {
    const [userId, setUserId] = useState('');
    const [name, setName] = useState('');

    const handleUpdate = async (e) => {
        e.preventDefault();
        try {
            console.log(name)
            await updateName(userId, name);
            alert('Name updated successfully!');
        } catch (error) {
            console.error('Error updating name:', error);
        }
    };

    return (
        <div className="container mt-4">
            <h2>Update Phone Number</h2>
            <form onSubmit={handleUpdate}>
                <div className="mb-3">
                    <label className="form-label">User ID</label>
                    <input type="number" className="form-control" value={userId} onChange={(e) => setUserId(e.target.value)} required />
                </div>
                <div className="mb-3">
                    <label className="form-label">Name</label>
                    <input type="text" className="form-control" value={name} onChange={(e) => setName(e.target.value)} required />
                </div>
                <button type="submit" className="btn btn-primary">Update Name</button>
            </form>
        </div>
    );
};

export default UpdateName;
