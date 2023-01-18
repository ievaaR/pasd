import "./Hero.css"
function Hero() {
    return(
        <>
            <div className="hero">
                <img alt="logo" src="https://i.ibb.co/tMMtv0C/logo-sper-2.png"/>
            </div>
            <div className="hero-text">
                <h1>Small ideas deliver big.</h1>
                <p>
                    <a className="show" href="/orders">
                        View Current  Orders
                    </a>
                </p>
                
            </div>
        </>
    );
 }

 export default Hero;