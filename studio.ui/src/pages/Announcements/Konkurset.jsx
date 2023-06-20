import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { styled } from '@mui/material/styles';
import Card from '@mui/material/Card';
import CardHeader from '@mui/material/CardHeader';
import CardMedia from '@mui/material/CardMedia';
import CardContent from '@mui/material/CardContent';
import Collapse from '@mui/material/Collapse';
import Avatar from '@mui/material/Avatar';
import IconButton from '@mui/material/IconButton';
import Typography from '@mui/material/Typography';
import { red } from '@mui/material/colors';
import FavoriteIcon from '@mui/icons-material/Favorite';
import ShareIcon from '@mui/icons-material/Share';
import ExpandMoreIcon from '@mui/icons-material/ExpandMore';
import MoreVertIcon from '@mui/icons-material/MoreVert'
import { Button, CardActionArea, CardActions } from '@mui/material';
import Img from './img/announcement.png';
import './styles.scss'




const ExpandMore = styled((props) =>
{
    const { expand, ...other } = props;
    return <IconButton {...other} />;
})(({ theme, expand }) => ({
    transform: !expand ? 'rotate(0deg)' : 'rotate(180deg)',
    marginLeft: 'auto',
    transition: theme.transitions.create('transform', {
        duration: theme.transitions.duration.shortest,
    }),
}));



export default function Announcement()
{

    const [expanded, setExpanded] = React.useState(false);

    const handleExpandClick = () =>
    {
        setExpanded(!expanded);
    };

    const [announcements, setAnnouncements] = useState([]);
    const [deadlines, setDeadlines] = useState([]);
    const [refreshKey, setRefreshKey] = useState('0');



    // announcements
    useEffect(() =>
    {
        axios.get('https://localhost:7137/api/Announcement/get-all-announcements')
            .then(response =>
            {
                setAnnouncements(response.data);
            }).catch(function (error)
            {
                console.log(error);
            });
    }, [refreshKey])

    // deadlines
    useEffect(() =>
    {
        axios.get('https://localhost:7137/api/Deadline/get-all-deadlines')
            .then(response =>
            {
                setDeadlines(response.data);
            }).catch(function (error)
            {
                console.log(error);
            });
    }, [refreshKey])


    return (
        <div className='container-konkurset-page'>
            {announcements.map((announcement) =>
            {
                const id = announcement.id;
                const title = announcement.title;
                const desc = announcement.description;
                const deadline = deadlines.find(d => d._id === announcement.DeadlineId);
                const openDate = deadline ? deadline.openDate : "";
                const closedDate = deadline ? deadline.closedDate : "";


                return (


                    <Card sx={{ maxWidth: 345 }} className='card-container'>
                        <CardHeader
                            avatar={
                                <Avatar sx={{ bgcolor: red[500] }} aria-label="recipe">
                                    A
                                </Avatar>
                            }
                            action={
                                <IconButton aria-label="settings">
                                    <MoreVertIcon />
                                </IconButton>
                            }
                            title="Data e hapjes"
                            subheader={openDate}

                        />
                        <CardMedia
                            component="img"
                            image={Img}
                            className='img-card'
                            height="140"
                        />
                        <CardContent>
                            <Typography variant="body2" color="text.secondary">
                                {title} <br />
                                {desc} <br />
                                Data mbylljes: {closedDate}
                            </Typography>
                        </CardContent>
                        <CardActions disableSpacing>
                            <IconButton aria-label="add to favorites">
                                <FavoriteIcon />
                            </IconButton>
                            <IconButton aria-label="share">
                                <ShareIcon />
                            </IconButton>
                            <ExpandMore
                                expand={expanded}
                                onClick={handleExpandClick}
                                aria-expanded={expanded}
                                aria-label="show more"
                            >
                                <ExpandMoreIcon />
                            </ExpandMore>
                        </CardActions>
                        <Collapse in={expanded} timeout="auto" unmountOnExit>
                            <CardContent>
                                <Typography paragraph>Method:</Typography>
                                <Typography paragraph>
                                    Heat 1/2 cup of the broth in a pot until simmering, add saffron and set
                                    aside for 10 minutes.
                                </Typography>
                                <Typography paragraph>
                                    Heat oil in a (14- to 16-inch) paella pan or a large, deep skillet over
                                    medium-high heat. Add chicken, shrimp and chorizo, and cook, stirring
                                    occasionally until lightly browned, 6 to 8 minutes. Transfer shrimp to a
                                    large plate and set aside, leaving chicken and chorizo in the pan. Add
                                    pimentón, bay leaves, garlic, tomatoes, onion, salt and pepper, and cook,
                                    stirring often until thickened and fragrant, about 10 minutes. Add
                                    saffron broth and remaining 4 1/2 cups chicken broth; bring to a boil.
                                </Typography>
                                <Typography paragraph>
                                    Add rice and stir very gently to distribute. Top with artichokes and
                                    peppers, and cook without stirring, until most of the liquid is absorbed,
                                    15 to 18 minutes. Reduce heat to medium-low, add reserved shrimp and
                                    mussels, tucking them down into the rice, and cook again without
                                    stirring, until mussels have opened and rice is just tender, 5 to 7
                                    minutes more. (Discard any mussels that don&apos;t open.)
                                </Typography>
                                <Typography>
                                    Set aside off of the heat to let rest for 10 minutes, and then serve.
                                </Typography>
                            </CardContent>
                        </Collapse>
                    </Card>







                    // <Card sx={{ maxWidth: 345 }} className='card-container'>
                    //     <CardActionArea>
                    //         <CardMedia
                    //             component="img"
                    //             image={Img}
                    //             className='img-card'
                    //             height="140"
                    //         />
                    //         <CardContent>
                    //             <Typography gutterBottom variant="h5" component="div" key={id}>
                    //                 {title}
                    //             </Typography>
                    //             <Typography variant="body2" color="text.secondary">
                    //                 {desc}
                    //             </Typography>
                    //             <Typography variant="body2" color="text.secondary">
                    //                 Data e hapjes:  {openDate} <br />
                    //                 Data e mbylljes: {closedDate}
                    //             </Typography>
                    //         </CardContent>
                    //     </CardActionArea>
                    //     <CardActions>
                    //         <Button size="small" className='btn-card' >Shiko</Button>
                    //     </CardActions>
                    // </Card>


                );
            })}
        </div>
    )
}