-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Oct 17, 2024 at 04:30 PM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.0.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `db_lms`
--

-- --------------------------------------------------------

--
-- Table structure for table `books`
--

CREATE TABLE `books` (
  `book_id` int(11) NOT NULL,
  `book_title` varchar(255) NOT NULL,
  `author` varchar(255) DEFAULT NULL,
  `book_publisher` varchar(255) DEFAULT NULL,
  `year_published` int(4) DEFAULT NULL,
  `category` varchar(100) DEFAULT NULL,
  `quantity` int(11) DEFAULT 0,
  `image_path` varchar(255) DEFAULT NULL,
  `borrowed_quantity` int(11) DEFAULT 0,
  `is_archived` tinyint(1) DEFAULT 0,
  `book_summary` text DEFAULT NULL,
  `book_type` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `books`
--

INSERT INTO `books` (`book_id`, `book_title`, `author`, `book_publisher`, `year_published`, `category`, `quantity`, `image_path`, `borrowed_quantity`, `is_archived`, `book_summary`, `book_type`) VALUES
(1, 'C# Programming', 'John Doe', 'Tech Publishers', 2020, 'Programming', 4, 'images/csharp.jpg', 3, 0, NULL, NULL),
(2, 'Learn Java', 'Jane Smith', 'Code World', 2016, 'Programming', 10, NULL, 0, 0, NULL, NULL),
(3, 'Database Systems', 'Richard Roe', 'Data Experts', 2018, 'Databases', 7, 'images/database.jpg', 1, 0, NULL, NULL),
(4, 'Modern Web Design', 'Alice White', 'Creative Web', 2021, 'Design', 11, 'C:\\Users\\Administrator\\Pictures\\image (3).png', 0, 0, NULL, NULL),
(5, 'Python for Beginners', 'David Green', 'PyPublishers', 2022, 'Programming', 8, 'images/python.jpg', 3, 0, NULL, NULL),
(6, 'Artificial Intelligence', 'Michael Black', 'AI Masters', 2023, 'AI', 3, 'images/ai.jpg', 0, 0, NULL, NULL),
(7, 'UX Principles', 'Emma Brown', 'UserX Publishing', 2017, 'Design', 9, 'images/ux.jpg', 5, 0, NULL, NULL),
(8, 'Data Science Handbook', 'Sophia Blue', 'Data Insights', 2019, 'Data Science', 6, 'images/datascience.jpg', 2, 0, NULL, NULL),
(9, 'Networking Fundamentals', 'James Grey', 'NetTech', 2020, 'Networking', 4, 'images/networking.jpg', 1, 0, NULL, NULL),
(10, 'Advanced JavaScript', 'Olivia Red', 'JS Experts', 2021, 'Web Development', 5, 'images/javascript.jpg', 3, 0, NULL, NULL),
(28, 'DSADASD', 'DASDAS', 'ASDAS', 2024, 'test', 5, 'C:\\Users\\Administrator\\Pictures\\Screenshots\\Screenshot (2).png', 0, 0, NULL, NULL),
(42, 'dsada', 'dasdsad', 'dasdsadas', 2009, 'test', 9, 'H:\\Project\\LibraryManagement\\LibraryManagement\\bin\\Debug\\Images\\books_default.png', 0, 0, NULL, NULL),
(43, 'The legend of avatar', 'eson', 'asdasda', 2024, 'test', 4, 'C:\\Users\\Administrator\\Pictures\\Screenshots\\Screenshot (2).png', 0, 0, NULL, NULL),
(44, 'Avatar the last airbender', 'wangko', 'NA publisher', 2005, 'test', 3, 'H:\\Project\\LibraryManagement\\LibraryManagement\\bin\\Debug\\Images\\books_default.png', 0, 0, NULL, NULL),
(45, 'DSADASD', 'DASDAS', 'ASDAS', 2024, 'test', 5, 'C:\\Users\\Administrator\\Pictures\\Screenshots\\Screenshot (2).png', 0, 0, NULL, NULL),
(46, 'dsada', 'dasdsad', 'dasdsadas', 2009, 'test', 9, 'H:\\Project\\LibraryManagement\\LibraryManagement\\bin\\Debug\\Images\\books_default.png', 0, 0, NULL, NULL),
(47, 'The legend of avatar', 'eson', 'asdasda', 2024, 'test', 4, 'C:\\Users\\Administrator\\Pictures\\Screenshots\\Screenshot (2).png', 0, 0, NULL, NULL),
(48, 'Avatar the last airbender', 'wangko', 'NA publisher', 2005, 'test', 3, 'H:\\Project\\LibraryManagement\\LibraryManagement\\bin\\Debug\\Images\\books_default.png', 0, 0, NULL, NULL),
(49, 'DSADASD', 'DASDAS', 'ASDAS', 2024, 'test', 5, 'C:\\Users\\Administrator\\Pictures\\Screenshots\\Screenshot (2).png', 0, 0, NULL, NULL),
(50, 'dsada', 'dasdsad', 'dasdsadas', 2009, 'test', 9, 'H:\\Project\\LibraryManagement\\LibraryManagement\\bin\\Debug\\Images\\books_default.png', 0, 0, NULL, NULL),
(51, 'The legend of avatar', 'eson', 'asdasda', 2024, 'test', 4, 'C:\\Users\\Administrator\\Pictures\\Screenshots\\Screenshot (2).png', 0, 0, NULL, NULL),
(52, 'Avatar the last airbender', 'wangko', 'NA publisher', 2005, 'test', 3, 'H:\\Project\\LibraryManagement\\LibraryManagement\\bin\\Debug\\Images\\books_default.png', 0, 0, NULL, NULL),
(53, 'DSADASD', 'DASDAS', 'ASDAS', 2024, 'test', 5, 'C:\\Users\\Administrator\\Pictures\\Screenshots\\Screenshot (2).png', 0, 0, NULL, NULL),
(54, 'dsada', 'dasdsad', 'dasdsadas', 2009, 'test', 9, 'H:\\Project\\LibraryManagement\\LibraryManagement\\bin\\Debug\\Images\\books_default.png', 0, 0, NULL, NULL),
(55, 'The legend of avatar', 'eson', 'asdasda', 2024, 'test', 4, 'C:\\Users\\Administrator\\Pictures\\Screenshots\\Screenshot (2).png', 0, 0, NULL, NULL),
(56, 'Avatar the last airbender', 'wangko', 'NA publisher', 2005, 'test', 3, 'H:\\Project\\LibraryManagement\\LibraryManagement\\bin\\Debug\\Images\\books_default.png', 0, 0, NULL, NULL),
(57, 'C# Programming', 'John Doe', 'Tech Publishers', 2020, 'Programming', 5, 'images/csharp.jpg', 2, 0, NULL, NULL),
(58, 'Learn Java', 'Jane Smith', 'Code World', 2019, 'Programming', 10, 'images/java.jpg', 4, 0, NULL, NULL),
(59, 'Database Systems', 'Richard Roe', 'Data Experts', 2018, 'Databases', 7, 'images/database.jpg', 1, 0, NULL, NULL),
(60, 'Modern Web Design', 'Alice White', 'Creative Web', 2021, 'Design', 12, 'images/webdesign.jpg', 6, 0, NULL, NULL),
(61, 'Python for Beginners', 'David Green', 'PyPublishers', 2022, 'Programming', 8, 'images/python.jpg', 3, 0, NULL, NULL),
(62, 'Artificial Intelligence', 'Michael Black', 'AI Masters', 2023, 'AI', 3, 'images/ai.jpg', 0, 0, NULL, NULL),
(63, 'UX Principles', 'Emma Brown', 'UserX Publishing', 2017, 'Design', 9, 'images/ux.jpg', 5, 0, NULL, NULL),
(64, 'Data Science Handbook', 'Sophia Blue', 'Data Insights', 2019, 'Data Science', 6, 'images/datascience.jpg', 2, 0, NULL, NULL),
(65, 'Networking Fundamentals', 'James Grey', 'NetTech', 2020, 'Networking', 4, 'images/networking.jpg', 1, 0, NULL, NULL),
(66, 'Advanced JavaScript', 'Olivia Red', 'JS Experts', 2021, 'Web Development', 5, 'images/javascript.jpg', 3, 0, NULL, NULL),
(67, 'Machine Learning Basics', 'Tom Blue', 'AI Publishers', 2018, 'AI', 7, 'images/ml_basics.jpg', 2, 0, NULL, NULL),
(68, 'Flutter for Mobile', 'Sarah Gold', 'Mobile World', 2021, 'Mobile Development', 6, 'images/flutter.jpg', 1, 0, NULL, NULL),
(69, 'React and Redux', 'Chris Black', 'Web Dev Co', 2019, 'Web Development', 8, 'images/react.jpg', 4, 0, NULL, NULL),
(70, 'Big Data Analytics', 'George Silver', 'Data Publishers', 2017, 'Data Science', 10, 'images/bigdata.jpg', 5, 0, NULL, NULL),
(71, 'Design Thinking', 'Mary White', 'Creative Minds', 2020, 'Design', 5, 'images/designthinking.jpg', 3, 0, NULL, NULL),
(72, 'Cloud Computing Essentials', 'Henry Grey', 'Tech Horizons', 2019, 'Cloud', 4, 'images/cloud.jpg', 2, 0, NULL, NULL),
(73, 'DevOps Explained', 'Anne Green', 'Tech Ops', 2018, 'DevOps', 7, 'images/devops.jpg', 1, 0, NULL, NULL),
(74, 'Kubernetes in Action', 'Nick Black', 'Container Tech', 2022, 'Cloud', 6, 'images/kubernetes.jpg', 3, 0, NULL, NULL),
(75, 'Docker Deep Dive', 'Nina White', 'Container Tech', 2021, 'Cloud', 5, 'images/docker.jpg', 2, 0, NULL, NULL),
(76, 'Agile Development', 'Laura Blue', 'Agile Books', 2019, 'Software Development', 9, 'images/agile.jpg', 4, 0, NULL, NULL),
(77, 'Scrum Master Handbook', 'Carl Green', 'Agile Publishers', 2020, 'Software Development', 6, 'images/scrum.jpg', 2, 0, NULL, NULL),
(78, 'Git for Beginners', 'Peter Brown', 'Tech Git', 2021, 'Version Control', 8, 'images/git.jpg', 3, 0, NULL, NULL),
(79, 'Continuous Delivery', 'Sam Black', 'DevOps Masters', 2022, 'DevOps', 5, 'images/cd.jpg', 2, 0, NULL, NULL),
(80, 'Blockchain Basics', 'Lily Green', 'Crypto World', 2020, 'Blockchain', 6, 'images/blockchain.jpg', 1, 0, NULL, NULL),
(81, 'Ethereum Smart Contracts', 'Mike Grey', 'Crypto Publishers', 2021, 'Blockchain', 4, 'images/ethereum.jpg', 1, 0, NULL, NULL),
(82, 'Data Structures and Algorithms', 'Dan Red', 'Algo Experts', 2022, 'Programming', 7, 'images/dsa.jpg', 3, 0, NULL, NULL),
(83, 'Clean Code', 'Robert Cecil', 'Techie Press', 2019, 'Software Development', 5, 'images/cleancode.jpg', 2, 0, NULL, NULL),
(84, 'Refactoring', 'Martin Fowler', 'Refactor Press', 2020, 'Software Development', 4, 'images/refactoring.jpg', 1, 0, NULL, NULL),
(85, 'Effective Java', 'Joshua Bloch', 'Java Experts', 2018, 'Programming', 9, 'images/effectivejava.jpg', 6, 0, NULL, NULL),
(86, 'Introduction to Algorithms', 'Thomas Cormen', 'MIT Press', 2021, 'Algorithms', 7, 'images/intro_algorithms.jpg', 2, 0, NULL, NULL),
(87, 'The Pragmatic Programmer', 'Andrew Hunt', 'Pragmatic Bookshelf', 2018, 'Software Development', 8, 'images/pragmatic_programmer.jpg', 4, 0, NULL, NULL),
(88, 'JavaScript: The Good Parts', 'Douglas Crockford', 'JS World', 2021, 'Web Development', 5, 'images/js_goodparts.jpg', 2, 0, NULL, NULL),
(89, 'PHP and MySQL', 'Janet Grey', 'Web Masters', 2020, 'Web Development', 6, 'images/php_mysql.jpg', 1, 0, NULL, NULL),
(90, 'Linux System Administration', 'Paul White', 'Linux Experts', 2019, 'System Administration', 7, 'images/linux_admin.jpg', 3, 0, NULL, NULL),
(91, 'Penetration Testing', 'Mark Black', 'CyberTech', 2021, 'Cybersecurity', 4, 'images/pen_testing.jpg', 2, 0, NULL, NULL),
(92, 'Cybersecurity Fundamentals', 'Eve Green', 'TechSecure', 2022, 'Cybersecurity', 6, 'images/cybersec.jpg', 2, 0, NULL, NULL),
(93, 'Rust Programming', 'David Silver', 'Rusty Books', 2020, 'Programming', 5, 'images/rust.jpg', 1, 0, NULL, NULL),
(94, 'TypeScript in Practice', 'Alice Blue', 'TS World', 2021, 'Programming', 4, 'images/typescript.jpg', 1, 0, NULL, NULL),
(95, 'Scala for the Impatient', 'Horstmann', 'Functional Books', 2020, 'Functional Programming', 5, 'images/scala.jpg', 2, 0, NULL, NULL),
(96, 'Functional Programming in Java', 'Venkat Subramaniam', 'Java Pros', 2019, 'Programming', 7, 'images/functional_java.jpg', 3, 0, NULL, NULL),
(97, 'Elixir in Action', 'Saša Jurić', 'Elixir Publishers', 2020, 'Functional Programming', 6, 'images/elixir.jpg', 2, 0, NULL, NULL),
(98, 'Haskell Programming', 'Graham Hutton', 'Haskell Press', 2019, 'Functional Programming', 8, 'images/haskell.jpg', 4, 0, NULL, NULL),
(99, 'Programming Rust', 'Jim Blandy', 'Rust World', 2021, 'Programming', 5, 'images/programming_rust.jpg', 1, 0, NULL, NULL),
(100, 'Distributed Systems', 'Andrew Tanenbaum', 'Distributed Tech', 2020, 'Networking', 7, 'images/distributed_systems.jpg', 3, 0, NULL, NULL),
(101, 'Kotlin for Android', 'Dmitry Jemerov', 'Android Experts', 2021, 'Mobile Development', 6, 'images/kotlin.jpg', 2, 0, NULL, NULL),
(102, 'React Native', 'John Doe', 'Mobile Experts', 2022, 'Mobile Development', 5, 'images/react_native.jpg', 1, 0, NULL, NULL),
(103, 'Quantum Computing', 'Michael Brown', 'Quantum Publishers', 2023, 'Quantum Computing', 4, 'images/quantum.jpg', 0, 0, NULL, NULL),
(104, 'Swift Programming', 'Chris Lattner', 'Apple Dev', 2020, 'Mobile Development', 6, 'images/swift.jpg', 2, 0, NULL, NULL),
(105, 'Go in Action', 'William Kennedy', 'Go Experts', 2018, 'Programming', 7, 'images/go.jpg', 3, 0, NULL, NULL),
(106, 'The Art of Computer Programming', 'Donald Knuth', 'Addison-Wesley', 2022, 'Programming', 4, 'images/taocp.jpg', 2, 0, NULL, NULL),
(107, 'Python Tricks', 'Dan Bader', 'Real Python', 2019, 'Programming', 10, 'images/python_tricks.jpg', 4, 0, NULL, NULL),
(108, 'Deep Learning with Python', 'François Chollet', 'Manning', 2020, 'AI', 6, 'images/dl_python.jpg', 3, 0, NULL, NULL),
(109, 'The Elements of Computing Systems', 'Noam Nisan', 'MIT Press', 2021, 'Computer Science', 7, 'images/computing_systems.jpg', 2, 0, NULL, NULL),
(110, 'Compilers: Principles, Techniques, and Tools', 'Alfred Aho', 'Pearson', 2022, 'Computer Science', 5, 'images/compilers.jpg', 3, 0, NULL, NULL),
(111, 'Data-Intensive Applications', 'Martin Kleppmann', 'O\'Reilly', 2020, 'Data Science', 8, 'images/data_intensive.jpg', 4, 0, NULL, NULL),
(112, 'Grokking Algorithms', 'Aditya Bhargava', 'Manning', 2019, 'Algorithms', 9, 'images/grokking_algorithms.jpg', 5, 0, NULL, NULL),
(113, 'Clean Architecture', 'Robert C. Martin', 'Tech Experts', 2018, 'Software Architecture', 7, 'images/clean_architecture.jpg', 2, 0, NULL, NULL),
(114, 'Introduction to Networking', 'Charles Severance', 'Net Tech', 2021, 'Networking', 4, 'images/networking_intro.jpg', 2, 0, NULL, NULL),
(115, 'The Linux Command Line', 'William Shotts', 'Linux Pros', 2019, 'System Administration', 6, 'images/linux_command.jpg', 1, 0, NULL, NULL),
(116, 'Operating Systems', 'Abraham Silberschatz', 'OS Masters', 2020, 'Computer Science', 5, 'images/operating_systems.jpg', 2, 0, NULL, NULL),
(117, 'Microservices Patterns', 'Chris Richardson', 'Cloud Publishers', 2021, 'Cloud', 7, 'images/microservices.jpg', 3, 0, NULL, NULL),
(118, 'The Mythical Man-Month', 'Frederick Brooks', 'Addison-Wesley', 2019, 'Software Development', 9, 'images/mythical_man.jpg', 4, 0, NULL, NULL),
(119, 'Concurrency in Go', 'Katherine Cox-Buday', 'Go Masters', 2020, 'Programming', 5, 'images/concurrency_go.jpg', 2, 0, NULL, NULL),
(120, 'Site Reliability Engineering', 'Betsy Beyer', 'O\'Reilly', 2022, 'DevOps', 8, 'images/sre.jpg', 4, 0, NULL, NULL),
(121, 'Terraform: Up & Running', 'Yevgeniy Brikman', 'Cloud Engineers', 2021, 'Cloud', 6, 'images/terraform.jpg', 2, 0, NULL, NULL),
(122, 'Pro Git', 'Scott Chacon', 'Git Pros', 2019, 'Version Control', 7, 'images/pro_git.jpg', 3, 0, NULL, NULL),
(123, 'Head First Design Patterns', 'Eric Freeman', 'O\'Reilly', 2020, 'Software Architecture', 9, 'images/design_patterns.jpg', 4, 0, NULL, NULL),
(124, 'Ansible for DevOps', 'Jeff Geerling', 'Automation Experts', 2021, 'DevOps', 6, 'images/ansible.jpg', 2, 0, NULL, NULL),
(125, 'Building Microservices', 'Sam Newman', 'Cloud Publishers', 2022, 'Cloud', 7, 'images/microservices_building.jpg', 3, 0, NULL, NULL),
(126, 'Effective DevOps', 'Jennifer Davis', 'DevOps Masters', 2019, 'DevOps', 5, 'images/effective_devops.jpg', 2, 0, NULL, NULL),
(127, 'dsadsad', 'asdasd', 'dasdasd', 2024, 'test', 1, 'H:\\Project\\LibraryManagement\\LibraryManagement\\bin\\Debug\\Images\\books_default.png', 0, 0, NULL, NULL),
(128, 'dsadsa', 'dasas', 'dasdasd', 2024, 'Reserved', 1, 'H:\\Project\\LMS\\LMS\\bin\\Debug\\Images\\books_default.png', 0, 0, NULL, NULL),
(129, 'aaaaaaaaaaaaaaaa', 'aaaaaaaaaaaaaaaaaaa', 'aaaaaaaaaaaaaaaa', 2024, 'Reserved', 1, 'H:\\Project\\LMS\\LMS\\bin\\Debug\\Images\\books_default.png', 0, 0, NULL, NULL),
(130, 'DASSAD', 'ASDASDSA', 'DASDASDAS', 2024, 'Reserved', 1, 'H:\\Project\\LMS\\LMS\\bin\\Debug\\Images\\books_default.png', 0, 0, '2', 'Fiction/Nonfiction');

-- --------------------------------------------------------

--
-- Table structure for table `borrowers`
--

CREATE TABLE `borrowers` (
  `borrower_id` int(11) NOT NULL,
  `name` varchar(100) NOT NULL,
  `section_course` varchar(100) DEFAULT NULL,
  `address` varchar(255) DEFAULT NULL,
  `contact_number` varchar(15) DEFAULT NULL,
  `email_address` varchar(100) DEFAULT NULL,
  `return_date` date DEFAULT NULL,
  `book_id` int(11) DEFAULT NULL,
  `processed_by` int(11) DEFAULT NULL,
  `is_returned` tinyint(1) DEFAULT 0,
  `date_returned` datetime DEFAULT NULL,
  `user_who_returned` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `borrowers`
--

INSERT INTO `borrowers` (`borrower_id`, `name`, `section_course`, `address`, `contact_number`, `email_address`, `return_date`, `book_id`, `processed_by`, `is_returned`, `date_returned`, `user_who_returned`) VALUES
(35, 'dasasd', 'BSIT', 'dsasadsad', '3123213', 'dasdas@gmail.com', '2024-10-18', 1, 5, 1, '2024-10-17 21:11:57', '5'),
(36, 'dasdas', 'BSIT', 'dsadasas', '2313', 'dasdsa@gmail.com', '2024-10-18', 1, 5, 1, '2024-10-17 21:52:18', '5');

-- --------------------------------------------------------

--
-- Table structure for table `librarians`
--

CREATE TABLE `librarians` (
  `librarian_id` int(11) NOT NULL,
  `name` varchar(100) NOT NULL,
  `birth_date` date DEFAULT NULL,
  `address` varchar(255) DEFAULT NULL,
  `contact_no` varchar(20) DEFAULT NULL,
  `email_address` varchar(100) DEFAULT NULL,
  `position` varchar(50) DEFAULT NULL,
  `username` varchar(50) NOT NULL,
  `password` varchar(100) NOT NULL,
  `photo_path` varchar(255) DEFAULT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `librarians`
--

INSERT INTO `librarians` (`librarian_id`, `name`, `birth_date`, `address`, `contact_no`, `email_address`, `position`, `username`, `password`, `photo_path`, `created_at`) VALUES
(5, 'Erickson', '2002-09-10', 'DSADA', '09225485', 'eson@gmail.com', 'Head Librarian', 'cas', '$2a$11$JFPMI6icjzu8qZSdW7r6EeOcPFyg45ft.uYn9pN.ij6Uwb6Ri6Z32', 'C:\\Users\\Administrator\\Pictures\\image (3).png', '2024-09-23 15:10:27'),
(20, 'admin', '2024-10-16', 'asdas', '1224', 'admin@gmail.com', 'Admin', 'admin123', '$2a$11$kUwi/QLO2spQfsKSMbxSZOHHnrbP4GM5d07Eo55zIu1ayC1JR5rFu', 'C:\\Users\\Administrator\\Downloads\\logo.png', '2024-10-17 14:28:57');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `books`
--
ALTER TABLE `books`
  ADD PRIMARY KEY (`book_id`);

--
-- Indexes for table `borrowers`
--
ALTER TABLE `borrowers`
  ADD PRIMARY KEY (`borrower_id`),
  ADD KEY `book_id` (`book_id`);

--
-- Indexes for table `librarians`
--
ALTER TABLE `librarians`
  ADD PRIMARY KEY (`librarian_id`),
  ADD UNIQUE KEY `username` (`username`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `books`
--
ALTER TABLE `books`
  MODIFY `book_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=131;

--
-- AUTO_INCREMENT for table `borrowers`
--
ALTER TABLE `borrowers`
  MODIFY `borrower_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=37;

--
-- AUTO_INCREMENT for table `librarians`
--
ALTER TABLE `librarians`
  MODIFY `librarian_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `borrowers`
--
ALTER TABLE `borrowers`
  ADD CONSTRAINT `borrowers_ibfk_1` FOREIGN KEY (`book_id`) REFERENCES `books` (`book_id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
