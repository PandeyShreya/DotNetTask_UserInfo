import React from 'react';
import { Link } from 'react-router-dom';

const UserCardList = ({ user, onDelete }) => {
    const handleDelete = (e) => {
        e.preventDefault();
        onDelete(user.id); // Call the delete function passed as a prop
    };

    return (
        <div className="container mb-3">
            <div className="card" style={{ maxWidth: '100%' }}>
                <div className="row g-0">
                    <div className="col-md-8">
                        <div className="card-body d-flex justify-content-between align-items-center">
                            <div>
                                <h5 className="card-title">{user.name}</h5>
                                <p className="card-text"><strong>Id:</strong> {user.id}</p>
                                <p className="card-text"><strong>Occupation:</strong> {user.occupation}</p>
                            </div>
                            <div>
                                   <Link key={user.id} to={`/users/${user.id}`} className="btn btn-primary me-2">
                                    View
                                </Link>
                                <button 
                                    className="btn btn-danger" 
                                    onClick={handleDelete} // Delete button
                                >
                                    Delete
                                </button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default UserCardList;
