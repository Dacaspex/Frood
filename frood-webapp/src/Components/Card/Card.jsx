const Card = ({ children, header }) => {
    return (
        <div className='card-container mt-x'>
            <div className='card-header'>
                { header }
            </div>
            <div className='card'>
                { children }
            </div>
        </div>
    );
};

export default Card;